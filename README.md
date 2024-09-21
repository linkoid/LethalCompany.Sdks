# Lethal Company Modding SDKs and Templates
[![GitHub](https://img.shields.io/badge/GitHub-%23121011.svg?logo=github&logoColor=white)](https://github.com/linkoid/LethalCompany.Sdks)
[![Stars](https://img.shields.io/github/stars/linkoid/LethalCompany.Sdks)](https://github.com/linkoid/LethalCompany.Sdks/stargazers)
[![License](https://img.shields.io/github/license/linkoid/LethalCompany.Sdks)](https://github.com/linkoid/LethalCompany.Sdks/tree/main?tab=MIT-1-ov-file)

[![Lethal Company Modding](https://custom-icon-badges.demolab.com/badge/Lethal_Company-Modding-FF3600.svg?labelColor=black&logo=lethalcompany)](https://lethal.wiki/)
[![dotnet](https://img.shields.io/badge/dotnet-512BD4?logo=dotnet)](https://dotnet.microsoft.com/en-us/download)
[![MSBuild](https://custom-icon-badges.demolab.com/badge/MSBuild-B35601.svg?logo=msbuild)](https://learn.microsoft.com/en-us/visualstudio/msbuild/msbuild)
[![C#](https://img.shields.io/badge/C%23-239120)](https://dotnet.microsoft.com/en-us/languages/csharp)
[![SmiteUnit](https://custom-icon-badges.demolab.com/badge/SmiteUnit-1F73D5.svg?logo=smiteunit)](https://github.com/linkoid/SmiteUnit)

This monorepo contains source code for multiple SDK and template packages which aid in Lethal Company Modding.

| Project                                | Description                                                | Latest Package |
|----------------------------------------|------------------------------------------------------------|:--------------:|
| [Common.Build](/Common.Build)          | Find the local installation of Lethal Company.             | [![NuGet](https://img.shields.io/nuget/v/Linkoid.LethalCompany.Common.Build  )](https://www.nuget.org/packages/Linkoid.LethalCompany.Common.Build/  ) | 
| [Plugin.Build](/Plugin.Build)          | Build and run a Lethal Company plugin.                     | [![NuGet](https://img.shields.io/nuget/v/Linkoid.LethalCompany.Plugin.Build  )](https://www.nuget.org/packages/Linkoid.LethalCompany.Plugin.Build/  ) | 
| [Test.Build  ](/Test.Build  )          | Build a test project for a Lethal Company plugin.          | [![NuGet](https://img.shields.io/nuget/v/Linkoid.LethalCompany.Test.Build    )](https://www.nuget.org/packages/Linkoid.LethalCompany.Test.Build/    ) | 
| [Test.Templates](/Test.Templates)      | Templates for Lethal Company plugin test projects.         | [![NuGet](https://img.shields.io/nuget/v/Linkoid.LethalCompany.Test.Templates)](https://www.nuget.org/packages/Linkoid.LethalCompany.Test.Templates/) |

## Why more SDKs and Templates?
Many of the existing SDKs and Templates include almost everything you could need. *Almost*.
They can't solve every problem though, and it can be difficult to combine the functionality of one SDK or template with another.
These SDKs are designed to work well with other templates, and not interfere with other SDKs.
By leveraging the full power of MSBuild, these SDKs will automatically detect the local installation of Lethal Company,
and copy the built plugin to the plugins folder automatically, then start the game with the IDE's play button or `dotnet run`.

## The Test Framework
**These templates include everything needed to immediately start writting tests using __SmiteUnit__**.
SmiteUnit will inject unit tests into Lethal Company when the plugin initializes, allowing to test more complex
scenarios that weren't possible before. Has a harmony transpilier been throwing lots of errors? Throw that patch in a 
SmiteUnit Test and automate the test process! Did a game update break lots of functions? Run all the tests to see what code needs fixed.
See more details about using SmiteUnit Templates in the Test.Template README: <https://github.com/linkoid/LethalCompany.Sdks/tree/main/Test.Templates#SmiteUnit-Templates>
