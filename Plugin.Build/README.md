# Lethal Company Plugin Build SDK
Provides MSBuild properties and targets for building and running a Lethal Company plugin.

## Usage
To use this package, add a package reference to the project:
```xml
<PackageReference Include="Linkoid.LethalCompany.Common.Build" Version="*" PrivateAssets="all" />
```

## Features
* Automatically locates local Lethal Company installation with [LethalCompany.Common.Build](https://github.com/linkoid/LethalCompany.Sdks/tree/main/Common.Build#Lethal-Company-Common-Build-SDK).
* Built plugin is copied to the plugins folder of the target game.
* Configures debug symbols to hide parent path and be compatible with mono.
* The IDE's play button / `dotnet run` will start the game.
* Does not bundle or transitively reference any assemblies.
  * Can easily be added to existing projects that already have their own references.
  * Can specify to reference local game assemblies if not using GameLibs packages.

## MSBuild Properties
* `<PluginName>`
  * The thunderstore safe name for the plugin.
  * Default: `$(MSBuildProjectName)` with common invalid characters removed
* `<StartGameOnRun>`
  * Start the game when using play button or `dotnet run`.
  * Default: `true` 
* `<EnableGameReferences>`
  * Add game assembly references from the local game installation. 
  * Default: `false`
* `<EnableUnityReferences>`
  * Add Unity assembly references from the local game installation.
  * Default: use value of EnableGameReferences
* `<CopyFilesToPluginOutputDirectoryOnBuild>`
  * Copy the plugin to the game's plugin folder after it's built.
  * Default: `true`
* `<CopyFilesToPluginOutputDirectoryOnRun>`
  * Copy the plugin to the game's plugin folder right before the game is run.
  * Default: `true`
* `<PluginOutputSubdirectory>`
  * The path relative to BepInEx/plugins/ to which the plugin will be copied.
  * Default: `$(Authors)-$(PluginName)` or `$(PluginName)`
* See additional configurable properties inherited from [LethalCompany.Common.Build](https://github.com/linkoid/LethalCompany.Sdks/tree/main/Common.Build#MSBuild-Properties).

## MSBuild Item Metadata
### CopyToPluginOutputDirectory
Anything copied to the build output directory will also be copied to the 
plugin output. It is possible to also specify items that aren't copied 
to the output directory to also be copied to plugin output.
```xml
<ItemGroup>
  <None Include="NOTICE.txt" CopyToPluginOutputDirectory="Always" />
</ItemGroup>
```

By default, the following files are copied to the plugin output if they are found:
* README.md
* README.txt
* manifest.json

This behaviour can be overriden by explicitly specifying not to copy these files.
```xml
<ItemGroup>
  <None Update="README.txt" CopyToPluginOutputDirectory="Never" />
</ItemGroup>
```

## Example
An example of using this SDK can be seen in the [Plugin Build Test Project](https://github.com/linkoid/LethalCompany.Sdks/blob/main/Plugin.Build.Tests/Plugin.Build.Tests.csproj).
