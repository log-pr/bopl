using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HiddenAbilitiesMod.Patches;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace HiddenAbilities
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class HiddenAbilitiesBase : BaseUnityPlugin
    {
        private const string ModGUID = "fawd.HiddenAbilities";
        private const string ModName = "Hidden Abilities";
        private const string ModVersion = "1.2.0";

        private readonly Harmony harmony = new Harmony(ModGUID);

        private static HiddenAbilitiesBase Instance;

        internal ManualLogSource mls;

        string[] config;

        void Awake()
        {

            if (Instance == null)
            {
                Instance = this;
            }

            //creates the BepInEx logger so we can add debuggin info
            mls = BepInEx.Logging.Logger.CreateLogSource(ModGUID);
            mls.LogInfo("The hidden ability mod has awoken.");

            //reads the config file if it exists, otherwise creates one with default settings
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string cfgFilePath = Path.Combine(assemblyFolder, "HiddenAbilitiesConfig.txt");
            if (File.Exists(cfgFilePath))
            {
                // Read all the content in one string and display the string 
                config = File.ReadAllLines(cfgFilePath);
                foreach(string line in config) 
                {
                    mls.LogInfo(line);
                }
            }
            else
            {
                string text = "Hide abilities for local players: 0";
                File.WriteAllText(cfgFilePath, text);
                config = File.ReadAllLines(cfgFilePath);
            }

            //patches the mods
            harmony.PatchAll(typeof(HiddenAbilitiesBase));

            //which patch is ran is dependant on config file information
            if (config[0].EndsWith("0"))
            {
                harmony.PatchAll(typeof(SlimeControllerPatchNonLocalOnly));
            }
            else if (config[0].EndsWith("1"))
            {
                harmony.PatchAll(typeof(SlimeControllerPatch));
            }
            else
            {
                mls.LogInfo("WARNING: Hidden Ability Mod did not activate -- config file formatting error.");
            }
        }
    }
}