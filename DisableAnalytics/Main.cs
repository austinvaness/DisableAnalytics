using HarmonyLib;
using Sandbox.Engine.Analytics;
using System;
using System.Reflection;
using VRage.Plugins;

namespace avaness.DisableAnalytics
{
    public class Main : IPlugin
    {
        public void Dispose()
        {

        }

        public void Init(object gameInstance)
        {
            Harmony harmony = new Harmony("avaness.DisableAnalytics");

            Type type = typeof(MySpaceAnalytics);
            HarmonyMethod disabled = new HarmonyMethod(typeof(Main).GetMethod("Disabled"));
            foreach (MethodInfo m in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                harmony.Patch(m, disabled);
            }
        }

        public void Update()
        {

        }

        public static bool Disabled()
        {
            return false;
        }
    }
}
