ASP.NET Core & EntityFramework Core Based Calendaro Projects for bussines mangment

This project is created using ASP.NET Core and EntityFramework Core.
![HomePage](https://user-images.githubusercontent.com/32790015/56864250-278d9580-69b8-11e9-86b2-11d8f0c1942f.png)
![Contact](https://user-images.githubusercontent.com/32790015/56864219-ca91df80-69b7-11e9-8ab6-f38eadd4cd79.png)
![ListOfServices](https://user-images.githubusercontent.com/32790015/56864204-a59d6c80-69b7-11e9-972e-bce36938b6e6.png)




Prerequirements

    Visual Studio 2017/ VS Code
    .NET Core SDK
    MySQL Server

How To Run

    VS 2017/2019    
        Open solution in Visual Studio 2017
        Restore packages
        Rebuild the project
        Run the application.

    VSCode/Console
        npm restore inside the project folder
        dotner run to run the project


Problems:

If codegenerator error happens change folder from 2.2.0 to 2.2.0-rtm-35687


The site name in the QR Code is taken from the project name you choose when initially creating your project. You can change it by looking for the GenerateQrCodeUri(string email, string unformattedKey) method in the /Areas/Identity/Pages/Account/Manage/EnableAuthenticator.cshtml.
