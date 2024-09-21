# Lethal Company Test Templates
[![GitHub](https://img.shields.io/badge/GitHub-%23121011.svg?logo=github&logoColor=white)](https://github.com/linkoid/LethalCompany.Sdks/tree/main/Test.Templates#Lethal-Company-Test-Templates)
[![Stars](https://img.shields.io/github/stars/linkoid/LethalCompany.Sdks)](https://github.com/linkoid/LethalCompany.Sdks/stargazers)
[![License](https://img.shields.io/github/license/linkoid/LethalCompany.Sdks)](https://github.com/linkoid/LethalCompany.Sdks/tree/main?tab=MIT-1-ov-file)

[![Lethal Company](https://custom-icon-badges.demolab.com/badge/Lethal_Company-Modding-FF3600.svg?labelColor=black&logo=lethalcompany)](https://lethal.wiki/)
[![dotnet](https://img.shields.io/badge/dotnet-512BD4?logo=dotnet)](https://dotnet.microsoft.com/en-us/download)
[![MSBuild](https://custom-icon-badges.demolab.com/badge/MSBuild-B35601.svg?logo=msbuild)](https://learn.microsoft.com/en-us/visualstudio/msbuild/msbuild)
[![C#](https://img.shields.io/badge/C%23-239120)](https://dotnet.microsoft.com/en-us/languages/csharp)
[![SmiteUnit](https://custom-icon-badges.demolab.com/badge/SmiteUnit-1F73D5.svg?logo=smiteunit)](https://github.com/linkoid/SmiteUnit)


This package provides several templates for creating test projects 
for Lethal Company plugins.

## Installation
Install the templates using the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-install)
```sh
dotnet new install Linkoid.LethalCompany.Test.Templates
```

# SmiteUnit Templates
The SmiteUnit templates provide boiler plate code for creating [SmiteUnit](https://github.com/linkoid/SmiteUnit/#smiteunit-) tests for Lethal Company plugins.

[Read more about SmiteUnit here](https://github.com/linkoid/SmiteUnit/#smiteunit-)

## Starting from Scratch
To start with a completely new plugin project, use the SmiteUnit Plugin template
```sh
dotnet new lcsmiteplugin -n MyPlugin
```

## Adding Tests to an Existing Plugin Project
To add tests to an existing plugin project, 
first create a new SmiteUnit test project for the solution.
Specify the name of the plugin for which these tests are being created with the `-p` argument. 
```sh
dotnet new lcsmitetests -n MyPlugin.Tests -p MyPlugin
```
This will create a separate test project next to the plugin project.

Next, navigate inside the plugin project folder, and add the Smite Injection template to the project.
```sh
cd ./MyPlugin/
dotnet new lcsmiteinject
```
This should automatically add the required package, but if it doesn't, it will print instructions on how to add the package references manually.

Finally, a few lines need to added to the plugin class to create and start the injection helper.
```cs
public class MyPlugin : BaseUnityPlugin
{
  void Awake()
  {
    // ...
#if DEBUG
    // Create an injection helper using the name of the test assembly
    var injectionHelper = LethalSmiteInjectionHelper.Create("MyPlugin.Tests");

    // Call Start() after creation to start tests immediately
    injectionHelper.Start();

    // Or don't call Start() and tests will automatically start on the next frame.
#endif
    // ...
  }
}
```
