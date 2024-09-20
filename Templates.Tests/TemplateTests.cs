using Microsoft.TemplateEngine.Authoring.TemplateVerifier;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace Linkoid.LethalCompany.Templates.Tests;

public class TemplateTests : TemplateTestBase
{
    [Test]
    [TestCase("SmiteUnitPlugin", "lcsmiteunitplugin", new[] { "-n", "Example.Plugin" })]
    [TestCase("SmiteUnitTests", "lcsmiteunittests", new[] { "-n", "Example.Plugin.Tests", "-p", "ExistingExample.Plugin" })]
    public async Task ProjectTemplate(string folderName, string shortName, string[] args)
    {
        var options = new TemplateVerifierOptions(templateName: shortName)
        {
            TemplatePath = FileLocator.GetTemplateLocation("Test.Templates", folderName),
            TemplateSpecificArgs = args,
            ScenarioName = folderName,
            SnapshotsDirectory = SnapshotsDirectory,
            DoNotPrependTemplateNameToScenarioName = true,
            DoNotAppendTemplateArgsToScenarioName = true,
        };

        await VerificationEngine.Execute(options);
    }


    [Test]
    [TestCase("SmiteUnitInjection", "lcsmiteunitinjection")]
    [TestCase("SmiteUnitTestClass", "lcsmiteunittestclass", new[] { "-n", "ExampleTestClass" })]
    public async Task ItemTemplate(string folderName, string shortName, string[]? args = default)
    {
        var outputDirectory = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));
        var projectDirectory = Directory.CreateDirectory(Path.Combine(outputDirectory.FullName, shortName));
        try
        {
            FileLocator.GetSourceFile("Templates.Tests", "Example.0.csproj")
                .CopyTo(Path.Combine(projectDirectory.FullName, "Example.0.csproj"), true);

            var options = new TemplateVerifierOptions(templateName: shortName)
            {
                TemplatePath = FileLocator.GetTemplateLocation("Test.Templates", folderName),
                TemplateSpecificArgs = args,
                ScenarioName = folderName,
                OutputDirectory = outputDirectory.FullName,
                SnapshotsDirectory = SnapshotsDirectory,
                DoNotPrependTemplateNameToScenarioName = true,
                DoNotAppendTemplateArgsToScenarioName = true,
                EnsureEmptyOutputDirectory = false,
                VerificationExcludePatterns = ["obj/**/*"],
            };

            await VerificationEngine.Execute(options);
        }
        finally
        {
            outputDirectory.Delete(true);
        }
    }
}