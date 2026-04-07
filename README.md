# Inventory-Management

> **Note:** this Angular app uses sample images located in `inventory-app/src/assets`. Replace `image1.jpg`, `image2.jpg`, or add your own assets in `assets/img/` with real photos. You can download images via curl or wget:
>
> ```bash
> cd inventory-app/src/assets/img
> curl -L <IMAGE_URL> -o product1.jpg
> ```
>
> The UI displays 3–5 products in various components for visual design; update them as needed.

#API
-Install the following extensions
    C# and C# dev kit (from micrisoft)
    C# Extensions(from Joskreativ)
    NuGet Package manager(from jmrog)
-Change the version as follows
    rm -f dotnet-install.sh && curl -L https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh && chmod +x dotnet-install.sh && ./dotnet-install.sh --version 8.0.100

-api project creation and setup

    ✅ 1️⃣ Create Solution & Folder Structure
        mkdir ECommerce
        cd ECommerce
        dotnet new sln -n ECommerce
        mkdir src

    ✅ 2️⃣ Create Projects (3‑Tier)
        🔹 API Layer (Presentation)
                dotnet new webapi -n ECommerce.Api -f net8.0 -o src/ECommerce.Api
        🔹 Business Layer (Services)
                dotnet new classlib -n ECommerce.Business -f net8.0 -o 
                src/ECommerce.Business
        🔹 Data Layer (EF Core + LINQ + SP)
                dotnet new classlib -n ECommerce.Data -f net8.0 -o src/ECommerce.Data
    ✅ 3️⃣ Add Projects to Solution
        dotnet sln add src/ECommerce.Api/ECommerce.Api.csproj
        dotnet sln add src/ECommerce.Business/ECommerce.Business.csproj
        dotnet sln add src/ECommerce.Data/ECommerce.Data.csproj
    ✅ 4️⃣ Add Project References(Important)
        API → Business + Data
            dotnet add src/ECommerce.Api/ECommerce.Api.csproj reference \
            src/ECommerce.Business/ECommerce.Business.csproj \
            src/ECommerce.Data/ECommerce.Data.csproj
        Business → Data
            dotnet add src/ECommerce.Business/ECommerce.Business.csproj reference \
            src/ECommerce.Data/ECommerce.Data.csproj
    ✅ 5️⃣ Install Required NuGet Packages
        📦 Data Layer (EF Core + SQL Server)
            dotnet add src/ECommerce.Data package Microsoft.EntityFrameworkCore --version 8.0.5
            dotnet add src/ECommerce.Data package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.5
            dotnet add src/ECommerce.Data package Microsoft.EntityFrameworkCore.Design --version 8.0.5
        📦 API Layer (EF Tools + Swagger + Auth)
            dotnet add src/ECommerce.Api package Microsoft.EntityFrameworkCore.Tools
            dotnet add src/ECommerce.Api package Swashbuckle.AspNetCore
            dotnet add src/ECommerce.Api package Microsoft.AspNetCore.Authentication.JwtBearer
            dotnet add src/ECommerce.Api package Microsoft.Data.SqlClient
            <!-- add automapper -->
            dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
        📦 Business Layer
            Must be empty
            ✅ Business layer should contain:
                Services
                DTOs
                Interfaces
                No EF Core
        ✅ 6️⃣ Clean Default Files (Optional but Recommended)
            rm src/ECommerce.Api/WeatherForecast.cs
            rm src/ECommerce.Api/Controllers/WeatherForecastController.cs
        ✅ 7️⃣ Create Folders (Recommended Structure)
            ~API
                mkdir src/ECommerce.Api/Controllers
                mkdir src/ECommerce.Api/Filters
                mkdir src/ECommerce.Api/Middlewares
            ~Business
                mkdir src/ECommerce.Business/Interfaces
                mkdir src/ECommerce.Business/Services
                mkdir src/ECommerce.Business/DTOs
            ~Data
                mkdir src/ECommerce.Data/Entities
                mkdir src/ECommerce.Data/Repositories
                mkdir src/ECommerce.Data/Migrations
                mkdir src/ECommerce.Data/Migrations/Sql
                mkdir src/ECommerce.Data/Keyless
                mkdir src/ECommerce.Data/Storage
        ✅ 8️⃣ Verify Build
            dotnet restore
            dotnet build
            (!important ✅ If this passes, our architecture skeleton is ready.)
        ✅ 9️⃣ Enable EF Core CLI (One‑time)
            dotnet tool install --global dotnet-ef
        ✅ 🔟 Create First Migration (Later) After adding AppDbContext & entities
            dotnet ef migrations add InitialCreate \
            --project src/ECommerce.Data \
            --startup-project src/ECommerce.Api
        ✅ 1️⃣1️⃣ Run the API
            dotnet run --project src/ECommerce.Api

-database connection
    ✅ OPTION 1 (Recommended): Azure SQL using Managed Identity
    👉 No username / password stored
    👉 Best practice for AZ‑204
    📄 appsettings.json (API project)
        {"ConnectionStrings": {
            "Sql": "Server=tcp:<your-server-name>.database.windows.net,1433;Database=MyDbName;
                    Authentication=Active Directory Managed Identity;Encrypt=True;
                    TrustServerCertificate=False;"}}
    ✅ Program.cs (.NET 8)
        using Microsoft.EntityFrameworkCore;
        using ECommerce.Data;
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("Sql")));
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    ✅ Azure SQL permissions (VERY IMPORTANT)
        After enabling System‑Assigned Managed Identity on your App Service:
        Run this in Azure SQL Query Editor:
            CREATE USER [<app-service-name>] FROM EXTERNAL PROVIDER;
            ALTER ROLE db_datareader ADD MEMBER [<app-service-name>];
            ALTER ROLE db_datawriter ADD MEMBER [<app-service-name>];
            (note:use a name for app-service-name, here i am using ecommerce-api)
-condigure azure db
    1.create sql server and database
    2.Create Resourse group(web app)
    3.After Resourse creation follow these steps
        ✅ STEP 1: Enable Managed Identity (MOST IMPORTANT)
        Azure Portal → App Service → your app
        Left menu → Identity
        System assigned → switch ON
        Click Save

        ✅ Azure now creates an identity for your app
        ✅ This identity name = App Service name
    4.Create connection string through ->App services->my app service->Environment variables->connectionstring
        Name:Sql
        Value:(connection string)eg: my connection string:Server=tcp:inventorydatabasedatabasewindows.net,1433;Database=ECommerceDb;Authentication=Active Directory Managed Identity;Encrypt=True;TrustServerCertificate=False;
        Type: SQL Azure
        Deployment slot setting ❌ Unchecked
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
-Migration 
    Migrate the data usning the entities from Ecommerce.Data and connection string from Ecommerce.Api
        dotnet ef migrations add InitialMigration --startup-project ../ECommerce.Api
    Update using same method
        dotnet ef database update --startup-project ../ECommerce.Api

