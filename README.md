# Your Bike Admin Backend

*This is a simple project I have done using C-Sharp programming language and ASP Dot Net Core framework.
Because this is my very first project after practice, so there could be a lot of mistakes. If you have any suggestion, please feel free to knock. I always welcome feedback. Thank you.*


This is a simple project developed using asp.net core for **Your Bike Admin App** mobile application. to get the mobile application project please visit: https://github.com/Neloy-SWE/Your-Bike-Admin-App

## Tools and Technologies:

1. Framework: asp.net core-8.0.303
2. Programming language: c-sharp-12
3. IDE: Microsoft Visual Studio Community 2022 (64-bit)-17.10.4

## packages:

1. Microsoft.EntityFrameworkCore: 8.0.3
2. Microsoft.EntityFrameworkCore.Relational: 8.0.3
3. Microsoft.EntityFrameworkCore.SqlServer: 8.0.3
4. Microsoft.AspNetCore.Authentication.JwtBearer: 8.0.3
5. System.IdentityModel.Tokens.Jwt: 7.4.1

## APIs:

1. apiAdmin/yourBike/Login
2. apiAdmin/yourBike/GetAllBikes
3. apiAdmin/yourBike/GetSingleBike{Id : int}
4. apiAdmin/yourBike/AddBike
5. apiAdmin/yourBike/DeleteBike{Id:int}
6. apiAdmin/yourBike/UpdateBike
7. apiAdmin/yourBike/GetAllNotifications
8. apiAdmin/yourBike/ReadNotification{NotificationId:int}


### to use these APIs

1. we will get a local server's url after run the project from output log. it will open swagger link. we will get all APIs and can check. we can implement it in any forntend project run in local server/pc.
2. we can create a dev tunnel(google it to setup) and follow the same process no. 1. but we will get a remote server url and we can implement it in any remote frontend project run in the same internet.