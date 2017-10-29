# Summary
This project is split into two parts with one being the base of the [API](https://github.com/RichTee/KB-41-StaticCodeAnalyser/tree/master/Project/StatischeCodeAnalyse) and the other being pure [C# static code analysis](https://github.com/RichTee/KB-41-StaticCodeAnalyser/tree/master/Project/POC%20-%20Analyser). The StatischeCodeAnalyse project is the base of the API that should, eventually, incorporate the POC - Analysis project to make it a full fleded working API. The goal is to create our own C# code analyser that handles the unique requirements of the Gamification Project.

# Documentation
Documentation can be found in the [docs folder](https://github.com/RichTee/KB-41-StaticCodeAnalyser/tree/master/Project/Doc). Additionally demo's of tested C# static code analysers are available in the demo folder. When working on the main project, StatischeCodeAnalyse and POC - Analyser, it is important to read the documentation about the Proof of Concept within the doc folder.

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
