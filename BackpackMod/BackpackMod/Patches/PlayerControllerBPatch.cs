using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BackpackMod;

namespace BackpackMod.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch {

        [HarmonyPatch(typeof(PlayerControllerB), "Awake")]
        [HarmonyPostfix]
        public static void InitPlayerItemSlots(PlayerControllerB __instance)
        {
            __instance.ItemSlots = (GrabbableObject[])(object)new GrabbableObject[BackpackModBase.inventorySize];
        }

    }
}
