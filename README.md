# CERental
Construction Equipment Rental Project

### Project Details
Dynamic web project with a separate backend server.

### Technology pool

- Microsoft Visual C# 6.0
- Microsoft .NET 4.5.2
- Microsoft ASP.NET MVC 5
- Console application

### Back-end
- Owin Security
- Entity Framework 6
- Castle Windsor

### Front-end
- Bootstrap
- Angular JS

# Running the project

### 1. Restoring nuget packages
1. Open nuget package manager. Click restore on popup

### 2. Building & Seeding a database
The solution is using Visual Studio's built in database engine. If you do not have it somehow or wish to use external database engine, then you must change the connection string. There are 2 connectionstring located in CERental.Web.Public (web.config) and CERental.Server (app.config).

1. Set CERental.Web.Public as a startup project
2. Open the package manager console
3. Select CERental.Data as a default project (dropdown!)
4. Insert command "Update-Database"

### 3. Run Application
1. Open solution properties
2. Select option "multiple startup projects"
3. If it's not already configured, select CERental.Server and CERental.Web.Public as startup projects
4. Run the application from Visual studio

# Using the project

1. Register account
2. Log in with provided details
3. Start using
