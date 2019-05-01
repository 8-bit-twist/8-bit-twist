
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

## Tools Used
Microsoft Visual Studio Community 2017 (Version 15.9.9), Microsoft Visual Studio Community 2019 (Version 16.0.3)

- C#
- ASP.Net Core
- Entity Framework
- MVC
- xUnit
- Azure

---------------------------------

## Data Model

### Overall Project Schema

#### Product Database Schema
![Product Database Schema](/assets/img/8Bit-Twist_ProductDB.png)

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
![User Database Schema](/assets/img/8Bit-Twist_UserDB.png)

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