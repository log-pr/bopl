using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HiddenAbilitiesMod.Patches;

namespace HiddenAbilities
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class HiddenAbilitiesBase : BaseUnityPlugin
    {
        private const string ModGUID = "fawd.HiddenAbilities";
        private const string ModName = "Hidden Abilities";
        private const string ModVersion = "1.1.0";

        private readonly Harmony harmony = new Harmony(ModGUID);

        private static HiddenAbilitiesBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(ModGUID);
            mls.LogInfo("The hidden ability mod has awoken.");

            harmony.PatchAll(typeof(HiddenAbilitiesBase));
            harmony.PatchAll(typeof(SlimeControllerPatch));
        }
    }
}
