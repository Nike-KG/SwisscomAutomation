# Swisscom Automation
## Requirements
* .net SDK 6.0
* Visual Studio or Visual Studio Code.

## Build
### Option 01 - Build by Command
Navigate to project folder and check *.csproj file exists in the folder. 

``` 
dotnet restore 
dotnet build
```

### Option 02 - Build using Visual Studio
1. Open .sln file in project folder.
2. Go to Build --> Rebuild Solution.

## Run Test
### Option 01 - Run by Command
Navigate to project folder and check *.csproj file exists in the folder. 

```  
dotnet test

```
### Option 02 - Run using Visual Studio
1. Open .sln file in project folder.
2. Go to Test --> Run All Tests.