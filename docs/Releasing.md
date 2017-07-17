# General
Currently, the App is released to Azure via Github.


# Setting up the App
## General
- Go to Azure Portal and log in
- New Resource --> Web + Mobile --> Web App
- Create Resource
- Navigate to the Resource
- Deplyoment Sub-Tab --> Quickstart
- Select ASP.NET Core
- Cloud based Source control
- Follow the guided steps to configure

## Azure
- Navigate to the Resource
- Select Settings --> Application Settings
- On the App Settings, create a variable called *Project* with the relative path defined in VS, for example "dist\netcoreapp1.1"
- Check, that the folder is not in .gitignore

## Troubleshooting
### 403 / 404
- Navigate to App
- Development Tools --> Console
- Check if Files are existing


# Setting up MongoDB
## General
- Go to Azure Portal and log in
- New Resource --> Databases --> "Database as a service for MongoDB"
- Follow the steps and create the Database
- Navigate in the Resource to Collections --> Browse
- Create the Database via "Add Database"
- Navigate in the Resource to Settings --> Connection String
- Add the Data to the appsettings.json
