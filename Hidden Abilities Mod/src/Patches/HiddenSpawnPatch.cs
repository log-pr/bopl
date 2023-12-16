using BepInEx.Logging;
using BoplFixedMath;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HiddenAbilities.Patches
{
    [HarmonyPatch(typeof(GameSessionHandler))]
    internal class HiddenSpawnPatch
    {
        [HarmonyPatch("SpawnPlayers")]
        [HarmonyPrefix]
        static void Patch()
        {
            List<Player> pl = PlayerHandler.Get().PlayerList();
            foreach (Player player in pl)
            {
                if (player != null)
                {
                    /*foreach (GameObject go in player.Abilities)
                    {
                        if (go != null)
                        {
                            go.SetActive(false);
                        }
                    }*/
                    player.AbilityIcons = new List<Sprite>();
                }
            }
        }
    }
}
