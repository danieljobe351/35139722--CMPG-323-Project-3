## CMPG 323 Project 3 - <35139722> Overview
# This project is an ASP.NET Core MVC web application designed to manage CRUD (Create, Read, Update, Delete) operations for project and client data. The application follows the Repository Design Pattern and is deployed on Azure for cloud hosting.

# Features:
- Full CRUD functionality for Projects and Clients.
- Implementation of the Repository Design Pattern for data access operations.
- Integration with SQL Server or Azure SQL Database.
- Deployment to Azure App Service for cloud hosting.
# Prerequisites
 To run this application, the following must be installed:
- .NET 8 SDK
- Visual Studio 2022
- SQL Server or Azure SQL Database for data storage.
- Access to Azure Portal for cloud deployment.
## Setup Instructions
1. Clone the Repository:
- Clone this project from GitHub by running the following command:
- git clone https://github.com/danieljobe351/35139722--CMPG-323-Project-3.git
 2. Update Connection Strings
- Update the appsettings.json file with your SQL Server or Azure SQL Database connection string:
 ``` bash "ConnectionStrings": {
  "DefaultConnection": "Server=<YourServer>;Database=<YourDatabase>;User Id=<YourUsername>;Password=<YourPassword>;"

}
```
3. Run the Application Locally
- To run the project locally:

Open the solution in Visual Studio 2022.
Build the project (Ctrl+Shift+B).
Ensure your database server is running.
Run the application via IIS Express or Kestrel by pressing F5.
4. Deploy the Application to Azure
-To deploy the app to Azure App Service:

Log in to your Azure Portal.
Set up an App Service and SQL Database.
In Visual Studio, right-click the project and select Publish.
Choose Azure App Service and complete the publishing process.
After deployment, the application will be accessible at the URL provided by Azure.
5. Accessing the Application
-Once the app is deployed or running locally, use the following routes:

# Projects Management:
- /Projects - to create, edit, view, and delete projects.
# Clients Management:
 - /Clients - to create, edit, view, and delete clients.
## Usage Instructions

# Create a New Project:
- Navigate to the "Projects" section and click "Create New". Fill in the project details and submit.

# Edit a Project: Select a project from the list, click "Edit", make the changes, and save.
- Delete a Project: Choose a project from the list and click "Delete". Confirm the deletion.

# Manage Clients:
- Similar functionality for Clients is available under the "Clients" section.

# Azure Deployment
The application is hosted on Azure and can be accessed at the following URL (replace with your Azure URL):
- https://telemetryportalmvc20240828094443.azurewebsites.net/

# Project Structure
objective
```bash
CMPG-323-Project-3/
├── CMPG323_Project3.sln
├── CMPG323_Project3/
│   ├── Controllers/
│   ├── Models/
│   ├── Views/
│   ├── Data/
│   ├── Repositories/
│   ├── appsettings.json
│   └── Program.cs
└── README.md
```
## References
Here are some resources used during development:

- ASP.NET Core MVC Documentation [https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-8.0]
- Azure App Service Documentation [https://learn.microsoft.com/en-us/azure/app-service/]
- Repository Pattern in ASP.NET Core [https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design]
- Additional tutorials and articles relevant to the project.
