# Summary
This project is split into two parts with one being the base of the API and the other being pure C# static code analysis. The StatischeCodeAnalyse project is the base of the API that should, eventually, incorporate the POC - Analysis project to make it a full fleded working API. The goal is to create our own C# code analyser that handles the unique requirements of the Gamification Project.

# Documentation
Documentation can be found in the docs folder.

# Installation
## Debugging
1. Clone the Project
2. Make sure to allow installation of missing NuGet packages
3. Right click the Project and go to Debug
4. Fill in Command line arguments anything such as code="c c" requirements="Requirements e"
5. Start debugging

## Production
1. Follow Debugging installation steps to make sure the project is working
2. Make a .exe of the project after confirming its functionality
3. Call the .exe with named arguments for code and requirements: --code="assignmentCode" --requirements="requirementsJsonFormat"
