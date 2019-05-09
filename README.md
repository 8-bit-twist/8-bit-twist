
# Project 8-Bit Twist
---------------------------------
## We are deployed on Azure!

https://8-bit-twist.azurewebsites.net/

**THIS SITE IS FOR LEARNING PURPOSES ONLY AND PURCHASES CANNOT BE MADE**

---------------------------------
## Web Application
The web application was written in C# using ASP.NET Core 2, Entity Framework Core, and the MVC framework and utilizes Razor views, HTML, and CSS. The application utilizes two SQL Databases for data storage.

This application simulates an e-commerce website.  Users can browse a virtual storefront of retro gaming consoles, view details about each individual item on offer, create a shopping basket of items they would like to purchase, and checkout through our secure checkout process.  Once a transaction is processed an email will be sent with a receipt, and users can view thier prior purchasing history at any time from their dashboard.

Users may view the site and contents without an account, but to add items to their cart they must first register with us.  User data is stored securely using encrypted hashtables. **NO PAYMENT INFORMATION IS STORED ON OUR DATABASE.**

---------------------------------

## User Claims and Policies
At time of registration Users are prompted to input their Email, First Name and Last Name, and Password.  Users are also prompted to check a box if they are a Computer.  We use this information to register specific claims about the user.  The claims registered are:

- The User's Full Name
- The User's Email address
- If the User considers themself a Computer or not

We use the Full Name claim as a way to customize our welcome page for each individual.  We use the Email claim to prevent access to certain parts of the site unless the user registers with a particular domain (NYI).  We use the Computer claim to allow Users who identify as a computer to access a unique page just for them.  That page is restricted by a Policy, and after creating an account with the Computer box checked and signing in that page can be accessed by clicking the Binary Numbers on the right side of the Nav Bar.

---------------------------------

## Tools Used
Microsoft Visual Studio Community 2017 (Version 15.9.9), Microsoft Visual Studio Community 2019 (Version 16.0.3)

- C#
- ASP.Net Core
- Entity Framework
- MVC
- xUnit
- Azure
- SendGrid

---------------------------------

## Data Model

### Overall Project Schema

#### Product Database Schema
![Product Database Schema](https://dev.azure.com/8-Bit-Twist/c4f8abbc-14a1-47e4-8712-e54fc0b376e0/_apis/git/repositories/773301b0-d668-4df1-a1dc-4d970332a194/Items?path=%2F8-Bit-Twist%2F8-Bit-Twist%2Fwwwroot%2FAssets%2FIMG%2F8Bit-Twist+ProductDB.png)

#### Model Properties and Requirements

##### Product
| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| SKU | string | YES |
| Price | decimal | YES |
| Description | string | YES |
| ImageURL | ImageUrl | YES |
| Generation | Enum | YES |
| ReleaseDate | Date | YES |

---------------------------

#### User Database Schema
![User Database Schema](https://dev.azure.com/8-Bit-Twist/c4f8abbc-14a1-47e4-8712-e54fc0b376e0/_apis/git/repositories/773301b0-d668-4df1-a1dc-4d970332a194/Items?path=%2F8-Bit-Twist%2F8-Bit-Twist%2Fwwwroot%2FAssets%2FIMG%2F8Bit-Twist+UserDB.png)

#### Model Properties and Requirements

##### ApplicationUser

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| UserName | string | YES |
| Email | string | YES |
| FirstName | string | YES |
| LastName | string | YES |
| Computer | bool |  |

##### UserClaims
| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| UserID (FK) | int | YES |
| ClaimType | list | YES |
| ClaimValue | list | YES |

---------------------------

## Change Log
1.0: *Initial Deployment* - 01 May 2019

------------------------------

## Authors
Benjamin Taylor
Andrew Roska