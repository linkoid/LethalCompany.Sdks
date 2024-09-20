using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkoid.LethalCompany.Templates.Tests;

internal static class FileLocator
{
    public static readonly DirectoryInfo CodeBase =
        (new FileInfo(typeof(FileLocator).Assembly.Location).Directory
            ?? new DirectoryInfo(Directory.GetCurrentDirectory()))
            // $(MSBuildSolutionDirectory)/$(MSBuildProjectName)/bin/$(Configuration)/$(TargetFramework)/
            .Parent?    // .../$(Configuration)/
            .Parent?    // .../bin/
            .Parent?    // .../$(MSBuildProjectName)/
            .Parent    // $(MSBuildSolutionDirectory)
            ?? new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", ".."));

    public static string GetTemplateLocation(string projectName, string templateName)
    {
        return Path.Combine(CodeBase.FullName, projectName, "bin",
#if DEBUG
            "Debug",
#else
            "Release",
#endif
            "netstandard2.0", "Content", templateName);
    }

    public static FileInfo GetSourceFile(string projectName, string filePath)
    {
        return new FileInfo(Path.Combine(CodeBase.FullName, projectName, filePath));
    }
}
