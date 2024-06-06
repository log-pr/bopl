using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoCooldownsMod.Patches;

namespace NoCooldownsMod
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class InfiniteDashBase : BaseUnityPlugin
    {
        private const string ModGUID = "fawd.NoCooldowns";
        private const string ModName = "Test Mod";
        private const string ModVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(ModGUID);

        private static InfiniteDashBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(ModGUID);
            mls.LogInfo("The test mod has awoken");

            harmony.PatchAll(typeof(InfiniteDashBase));
            harmony.PatchAll(typeof(CooldownPatch));
        }
    }
}
