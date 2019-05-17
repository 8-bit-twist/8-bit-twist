using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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

        public Payment(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public string Run(ApplicationUser user, Order order)
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType
            {
                name = _configuration["AuthorizeNet:LoginID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _configuration["AuthorizeNet:TransactionKey"]
            };

            long number = (long)order.CardNumber;

            creditCardType creditCard = new creditCardType
            {
                cardNumber = number.ToString(),
                expirationDate = "1219"
            };

            customerAddressType address = new customerAddressType
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                address = order.ShippingAddress,
                city = order.City,
                zip = order.Zip
            };

            paymentType payment = new paymentType { Item = creditCard };

            transactionRequestType transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = order.TotalPrice,
                payment = payment,
                billTo = address,
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
                        logText.AppendLine($"Successfully created transaction (ID: {response.transactionResponse.transId})");
                        logText.AppendLine($"Response Code: {response.transactionResponse.responseCode}");
                        logText.AppendLine($"Message Code: {response.transactionResponse.messages[0].code}");
                        logText.AppendLine($"Description: {response.transactionResponse.messages[0].description}");
                        logText.AppendLine($"Auth Code: {response.transactionResponse.authCode}");
                    }
                    else
                    {
                        if (response.transactionResponse.errors != null)
                        {
                            logText.AppendLine("Failed Transaction.");
                            logText.AppendLine($"Error Code: {response.transactionResponse.errors[0].errorCode}");
                            logText.AppendLine($"Error Message: {response.transactionResponse.errors[0].errorText}");
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
                }
            }
            else
            {
                logText.AppendLine("Transaction request resulted in null response");
            }
            return logText.ToString();
        }
    }
}
