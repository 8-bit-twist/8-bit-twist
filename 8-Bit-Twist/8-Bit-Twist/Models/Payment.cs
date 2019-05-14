using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models
{
    public class Payment
    {
        readonly IConfiguration _configuration;
        readonly UserManager<ApplicationUser> _userManager;
        readonly ILogger _logger;

        public Payment(IConfiguration configuration, UserManager<ApplicationUser> userManager, ILogger<Payment> logger)
        {
            _configuration = configuration;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task Run(Order order)
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType
            {
                name = _configuration["AuthorizeNet:LoginID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _configuration["AuthorizeNet:TransactionKey"]
            };

            creditCardType creditCard = new creditCardType
            {
                cardNumber = order.CardNumber,
                expirationDate = "1219"
            };

            ApplicationUser user = await _userManager.FindByIdAsync(order.ApplicationUserID);
            customerAddressType address = new customerAddressType
            {
                firstName = user.FirstName,
                lastName = user.FirstName,
                address = order.ShippingAddress,
                city = order.City,
                zip = order.Zip
            };

            paymentType payment = new paymentType { Item = creditCard };

            lineItemType[] lineItems = new lineItemType[order.OrderItems.Count];
            for (int i = 0; i < lineItems.Count(); i++)
            {
                OrderItem item = order.OrderItems[i];

                lineItems[i] = new lineItemType
                {
                    itemId = item.ProductID.ToString(),
                    name = item.Product.Name,
                    quantity = item.Quantity,
                    unitPrice = item.Price
                };
            }

            transactionRequestType transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = order.TotalPrice,
                payment = payment,
                billTo = address,
                lineItems = lineItems
            };

            createTransactionRequest request = new createTransactionRequest
            {
                transactionRequest = transactionRequest
            };

            createTransactionController controller = new createTransactionController(request);
            controller.Execute();

            createTransactionResponse response = controller.GetApiResponse();
            StringBuilder logText = new StringBuilder();

            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    if (response.transactionResponse.messages != null)
                    {
                        order.Completed = true;
                        logText.AppendLine($"Successfully created transaction (ID: {response.transactionResponse.transId})");
                        logText.AppendLine($"Response Code: {response.transactionResponse.responseCode}");
                        logText.AppendLine($"Message Code: {response.transactionResponse.messages[0].code}");
                        logText.AppendLine($"Description: {response.transactionResponse.messages[0].description}");
                        logText.AppendLine($"Auth Code: {response.transactionResponse.authCode}");
                        _logger.LogInformation(logText.ToString());
                    }
                    else
                    {
                        if (response.transactionResponse.errors != null)
                        {
                            logText.AppendLine("Failed Transaction.");
                            logText.AppendLine($"Error Code: {response.transactionResponse.errors[0].errorCode}");
                            logText.AppendLine($"Error Message: {response.transactionResponse.errors[0].errorText}");
                            _logger.LogWarning(logText.ToString());
                        }
                    }
                }
                else
                {
                    logText.AppendLine("Failed Transaction.");
                    if (response.transactionResponse != null && response.transactionResponse.errors != null)
                    {
                        logText.AppendLine($"Error Code: {response.transactionResponse.errors[0].errorCode}");
                        logText.AppendLine($"Error Message: {response.transactionResponse.errors[0].errorText}");
                    }
                    else
                    {
                        logText.AppendLine($"Error Code: {response.messages.message[0].code}");
                        logText.AppendLine($"Error Message: {response.messages.message[0].text}");
                    }
                    _logger.LogWarning(logText.ToString());
                }
            }
            else
            {
                _logger.LogWarning("Transaction request resulted in null response");
            }
        }
    }
}
