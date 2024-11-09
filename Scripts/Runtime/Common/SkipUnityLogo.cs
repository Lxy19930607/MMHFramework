#if !UNITY_EDITOR
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Rendering;


namespace MMHFramework
{
    [Preserve]
    public static class SkipUnityLogo
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void BeforeSplashScreen()
        {
            Task.Run(SkipSplashScreen);
        }

        private static void SkipSplashScreen()
        {
            SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
        }
    }
}
#endif