using System.Collections;
using System.Threading.Tasks;
using BepInEx.Logging;
using SmiteUnit.Framework;
using SmiteUnit.Unity;
using UnityEngine;

namespace SmiteUnitPlugin._0.Tests
{
    // The SmiteProcessAttribute tells the test adapter which program to start
    [SmiteProcess("%GAME_EXE_PATH%", "-logfile -")]
    public class TestClass : MonoBehaviour
    {
        private static TestClass Instance = null!;
        private static ManualLogSource Logger = null!;

        // The SmiteSetUpAttribute marks methods that should run before any test methods
        [SmiteSetUp]
        public static void SetUp()
        {
            Instance = new GameObject($"{nameof(TestClass)}").AddComponent<TestClass>();
            GameObject.DontDestroyOnLoad(Instance.gameObject);
            Instance.gameObject.hideFlags = HideFlags.HideAndDontSave;

            Logger = BepInEx.Logging.Logger.CreateLogSource(typeof(TestClass).Assembly.GetName().Name);
        }

        // The SmiteTestAttribute marks methods that can be run as tests
        [SmiteTest]
        public static void HelloWorldTest()
        {
            Logger.LogInfo("Hello World!");
        }

        // An async test can be run with a coroutine using the StartCoroutineTask extension method
        [SmiteTest]
        public static async Task CoroutineTest()
        {
            await Instance.StartCoroutineTask(MyLocalCoroutine());
            IEnumerator MyLocalCoroutine()
            {
                // Async test logic goes here
                yield return new WaitForSeconds(1);
                Logger.LogInfo("Waited for 1 second.");
            }
        }
    }
}
