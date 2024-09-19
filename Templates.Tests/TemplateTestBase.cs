using Microsoft.Extensions.Logging;
using Microsoft.TemplateEngine.Authoring.TemplateVerifier;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkoid.LethalCompany.Templates.Tests;

public abstract class TemplateTestBase
{
    protected ILoggerProvider LoggerProvider { get; } = new NUnitLoggerProvider();
    protected ILogger Logger { get; private set; } = null!;
    protected VerificationEngine VerificationEngine { get; private set; } = null!;
    protected string SnapshotsDirectory { get; private set; } = Path.Combine("TestResults", "Snapshots");

    [SetUp]
    public virtual void SetUp()
    {
        Logger = LoggerProvider.CreateLogger("TestRun");
        VerificationEngine = new(LoggerProvider.CreateLogger("VerificationEngine"));
    }
}
