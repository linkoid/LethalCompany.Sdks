using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace Example.Plugin
{
    [BepInPlugin("Example.Plugin", "Example_Plugin", "1.0")]
    public class Example_Plugin : BaseUnityPlugin
    {
        void Awake()
        {
            Logger.LogInfo($"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!");

#if DEBUG
            // Create an injection helper using the name of the test assembly
            var injectionHelper = LethalSmiteInjectionHelper.Create("Example.Plugin.Tests");

            // Call Start() after creation to start tests immediately
            injectionHelper.Start();

            // Or don't call Start() and tests will automatically start on the next frame.
#endif
        }
    }
}
