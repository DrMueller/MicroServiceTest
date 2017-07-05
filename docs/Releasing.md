# General
Currently, the app is released to Azure via Github.

# Proceeding
## General
- Go to Azure Portal and log in
- New Resource --> Web + Mobile --> Web App
- Create Resource
- Navigate to the Resource
- Deplyoment Sub-Tab --> Quickstart
- Select ASP.NET Core
- Cloud based Source control
- Follow the guided steps to configure

## Configuring specific folder
### Visual Studio
- Go the the Project Options
- Navigate to the "Build"-Tab
- Select the "Release"-Configuration
- Set the Output-Path to "..\dist\"
__Attention__ Visual Studio still adds "\netcoreapp1.1" automatically, so resetting the path means it has to be removed again!

### Azure
- Navigate to the Resource
- Select Settings --> Application Settings
- On the App Settings, create a variable called *Project* with the relative path defined in VS, for example "dist\netcoreapp1.1"
- Check, that the folder is not in .gitignore
