//-:cnd:noEmit
#if DEBUG // Test code usually isn't included in releases
//+:cnd:noEmit

using BepInEx.Logging;
using UnityEngine;
using SmiteUnit.Injection;

namespace SmiteUnitPlugin._0
{
    internal class LethalSmiteInjectionHelper : MonoBehaviour
    {
        public SmiteInjection? SmiteInjection { get; set; }
        public string? TestAssemblyName { get; set; }
        private bool m_Started = false;

        public static LethalSmiteInjectionHelper Create(string assemblyName)
        {
            string injectionName = $"SmiteInjection.{assemblyName}";
            var instance = new GameObject(injectionName).AddComponent<LethalSmiteInjectionHelper>();
            instance.TestAssemblyName = assemblyName;

            // Create a new SmiteInjection with the test assembly name
            instance.SmiteInjection = new SmiteInjection(assemblyName)
            {
                ExitStrategy = Application.Quit,                  // Use Unity's Application.Quit method to exit
                UsingDelayedExitStrategy = true,                  // Application.Quit doesn't exit immediately
                Logger = new SmiteToBepInExLogger(injectionName), // Route logging through BepInEx
            };

            // Prevent the game from destroying the helper
            GameObject.DontDestroyOnLoad(instance.gameObject);
            instance.gameObject.hideFlags = HideFlags.HideAndDontSave;

            return instance;
        }

        public void Start()
        {
            if (m_Started) return; // Debounce to allow calling Start() manually after creation
            // else
            
            m_Started = true;
            if (SmiteInjection != null) 
            {
                bool ranAnyTests = SmiteInjection.EntryPoint();
                if (!ranAnyTests)
                {
                    // If no tests ran, a "default" test may be run
                    // A default test should ALWAYS be temporary
                    // because this means a test will always run every time the game is
                    // started, preventing the game from being played normally.

                    //var defaultTestId = SmiteUnit.SmiteId.Method(new System.Reflection.AssemblyName(TestAssemblyName), "TestClass", "CoroutineTest");
                    //SmiteInjection.RunTest(defaultTestId);
                }
            }
        }

        void Update()
        {
            SmiteInjection?.UpdatePoint();
        }

        void OnDestroy()
        {
            SmiteInjection?.ExitPoint();
        }
    
        private class SmiteToBepInExLogger : SmiteUnit.Logging.ILogger
        {
            private readonly ManualLogSource m_BepInExLogger;

            public SmiteToBepInExLogger(ManualLogSource bepInExLogger)
            {
                m_BepInExLogger = bepInExLogger;
            }
            public SmiteToBepInExLogger(string sourceName)
                : this(BepInEx.Logging.Logger.CreateLogSource(sourceName))
            { }

            public void Log(SmiteUnit.Logging.LogLevel logLevel, object? data)
            {
                var bepInExLogLevel = logLevel switch
                {
                    SmiteUnit.Logging.LogLevel.Trace    => LogLevel.Debug,
                    SmiteUnit.Logging.LogLevel.Debug    => LogLevel.Debug,
                    SmiteUnit.Logging.LogLevel.Info     => LogLevel.Info,
                    SmiteUnit.Logging.LogLevel.Warning  => LogLevel.Warning,
                    SmiteUnit.Logging.LogLevel.Error    => LogLevel.Error,
                    SmiteUnit.Logging.LogLevel.Critical => LogLevel.Fatal,
                    SmiteUnit.Logging.LogLevel.None     => LogLevel.None,
                    _ => throw new System.ArgumentOutOfRangeException(nameof(logLevel)),
                };
                m_BepInExLogger.Log(bepInExLogLevel, data);
            }
        }
    }

}

//-:cnd:noEmit
#endif
//+:cnd:noEmit
