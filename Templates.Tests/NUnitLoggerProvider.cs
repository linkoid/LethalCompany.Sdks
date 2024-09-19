using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkoid.LethalCompany.Templates.Tests;

internal record class NUnitLoggerProvider(LogLevel MinimumLogLevel = LogLevel.Information) : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return new NUnitLogger(categoryName, MinimumLogLevel);
    }
    public void Dispose() { }
}


file class NUnitLogger(string categoryName, LogLevel minimumLogLevel) : ILogger
{
    private readonly string _categoryName = categoryName;
    private readonly LogLevel _minimumLogLevel = minimumLogLevel;

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return _minimumLogLevel <= logLevel && logLevel < LogLevel.None;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        string message = $"[{_categoryName}] {formatter(state, exception)}";

        switch (logLevel)
        {
            case LogLevel.Trace:
            case LogLevel.Debug:
            case LogLevel.Information:
                TestContext.Out.WriteLine(message);
                break;

            case LogLevel.Warning:
            case LogLevel.Error:
            case LogLevel.Critical:
                TestContext.Error.WriteLine(message);
                break;

            case LogLevel.None:
            default:
                break;
        }
    }
}
