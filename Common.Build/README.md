# Lethal Company Common Build SDK
Provides minimal MSBuild properties for finding a 
Lethal Company installation on the local machine and other misc. targets.

To use this package, add a package reference to the project:
```xml
<PackageReference Include="Linkoid.LethalCompany.Common.Build" Version="*" PrivateAssets="all" />
```

## MSBuild Properties
* `$(GameDirectory)`: The path to the local installation of Lethal Company
* `$(BepInExDirectory)`: The path to the BepInEx directory inside Lethal Company
* See the source code on github for more properties that are available to targets.

## Directory LethalCompany Props & Targets Files
Whenever this package is used, it automatically loads the first
`Directory.LethalCompany.props` and `Directory.LethalCompany.targets`
files that are found in any of the directories above the project.
This can be used to manually specify a custom game directory for a
project/all projects in a directory and it's subdirectories.
Even if lethal company can be found automatically, it can be overriden
to use a special version/installation of the game.

Here is an example `Directory.LethalCompany.props` file:
```xml
<Project>
  <PropertyGroup>
    <GameDirectory>C:\Path\To\Lethal Company\</GameDirectory>
  </PropertyGroup>
</Project>
```
