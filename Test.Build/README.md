# Lethal Company Test Build SDK
[![GitHub](https://img.shields.io/badge/GitHub-%23121011.svg?logo=github&logoColor=white)](https://github.com/linkoid/LethalCompany.Sdks/tree/main/Test.Build#Lethal-Company-Test-Build-SDK)
[![Stars](https://img.shields.io/github/stars/linkoid/LethalCompany.Sdks)](https://github.com/linkoid/LethalCompany.Sdks/stargazers)
[![License](https://img.shields.io/github/license/linkoid/LethalCompany.Sdks)](https://github.com/linkoid/LethalCompany.Sdks/tree/main?tab=MIT-1-ov-file)

[![Lethal Company](https://custom-icon-badges.demolab.com/badge/Lethal_Company-Modding-FF3600.svg?labelColor=black&logo=lethalcompany)](https://lethal.wiki/)
[![dotnet](https://img.shields.io/badge/dotnet-512BD4?logo=dotnet)](https://dotnet.microsoft.com/en-us/download)
[![MSBuild](https://custom-icon-badges.demolab.com/badge/MSBuild-B35601.svg?logo=msbuild)](https://learn.microsoft.com/en-us/visualstudio/msbuild/msbuild)

Provides MSBuild properties and targets for creating a project which tests a Lethal Company plugin.

## Usage
To use this package, add a package reference to the project:
```xml
<PackageReference Include="Linkoid.LethalCompany.Test.Build" Version="*" PrivateAssets="all" />
```

## Features
* Automatically locates local Lethal Company installation with [Linkoid.LethalCompany.Common.Build](https://github.com/linkoid/LethalCompany.Sdks/tree/main/Common.Build##Lethal-Company-Common-Build-SDK).
* Generates a `.runsettings` file with machine-specific file paths by using  [Linkoid.Build.Tasks.RunSettings](https://github.com/linkoid/Build.Sdks/tree/main/Tasks.RunSettings#run-settings-build-tasks).
* Copies files to the referenced plugin's folder instead of it's own separate folder. (If plugin copying is enabled.)

## MSBuild Properties
This package inherits all the properties from [LethalCompany.Plugin.Build](https://github.com/linkoid/LethalCompaty.Sdks/tree/main/Plugin.Build#MSBuild-Properties)
with some default values changed:
* `<StartGameOnRun>`
  * Disabled by default to match convention where tests cannot be run with play button or `dotnet run`.
  * Default: `false`
* `<CopyFilesToPluginOutputDirectoryOnBuild>` and `<CopyFilesToPluginOutputDirectoryOnRun>`
  * If `true`, will copy build output to the same plugin folder as the first `<ProjectReference>` to a lethal company plugin found.
  * Test assemblies often stand alone and are not required dependencies for a plugin unless using a test injection framework such as [SmiteUnit](https://github.com/linkoid/LethalCompany.Sdks/tree/main/Test.Templates#SmiteUnit-Templates).
  * Default: `false`


## Generated `.runsettings` File
When the project is built, this package will automatically generate a `.runsettings` file 
via [Linkoid.Build.Tasks.RunSettings](https://github.com/linkoid/Build.Sdks/tree/main/Tasks.RunSettings#run-settings-build-tasks). The following environment variables are included in the generated file:

* `GAME_DIRECTORY`: The full path to the Lethal Company game folder.
* `GAME_EXE_PATH`: The full path to the Lethal Company executable.
* `BEPINEX_DIRECTORY`: The full path to the BepInEx folder.

The values are determined at build time by the MSBuild properties of respective name. These environment variables can be used in the test program to avoid hardcoding file paths:
```cs
string cosmeticsDirectory = "%BEPINEX_DIRECTORY%/plugins/MoreCompanyCosmetics";
cosmeticsDirectory = System.Environment.ExpandEnvironmentVariables(cosmeticsDirectory);
foreach (string cosmeticFile in System.IO.Directory.EnumerateFiles(cosmeticsDirectory))
{
    AssertMyPluginWorksWith(cosmeticFile);
}
```

> [!NOTE]
> These environment variables will only be set in the test environment and should not be used in the plugin itself.

## Example
An example of using this SDK can be seen in the [SmiteUnitTests Template](https://github.com/linkoid/LethalCompany.Sdks/blob/main/Test.Templates/Content/SmiteUnitTests/SmiteUnitPlugin.0.Tests.csproj).
