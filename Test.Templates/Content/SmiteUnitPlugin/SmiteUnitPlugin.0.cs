using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace SmiteUnitPlugin._0
{
    [BepInPlugin("SmiteUnitPlugin.0", "SmiteUnitPlugin__0", "1.0")]
    public class SmiteUnitPlugin__0 : BaseUnityPlugin
    {
        void Awake()
        {
            Logger.LogInfo($"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!");

//-:cnd:noEmit
#if DEBUG
            // Create an injection helper using the name of the test assembly
            var injectionHelper = UnitySmiteInjectionHelper.Create("SmiteUnitPlugin.0.Tests");

            // Call Start() after creation to start tests immediately
            injectionHelper.Start();

            // Or don't call Start() and tests will automatically start on the next frame.
#endif
//+:cnd:noEmit
        }
    }
}