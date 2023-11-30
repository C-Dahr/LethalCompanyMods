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
    [HarmonyPatch(typeof(BoomboxItem))]
    internal class BoomboxItemPatch : GrabbableObject
    {

        [HarmonyPatch(typeof(BoomboxItem), "ItemActivate")]
        [HarmonyPostfix]
        public static void IncreaseInventory(ref PlayerControllerB ___playerHeldBy)
        {
            BackpackModBase.inventorySize = 6;
            GrabbableObject[] NewItemSlots = (GrabbableObject[])(object)new GrabbableObject[BackpackModBase.inventorySize];
            for (int i = 0; i < ___playerHeldBy.ItemSlots.Length; i++)
            {
                NewItemSlots[i] = ___playerHeldBy.ItemSlots[i];
            }
            ___playerHeldBy.ItemSlots = NewItemSlots;
            ___playerHeldBy.DropAllHeldItems();
            HUDManagerPatch.SetHUDInventory();
        }

    }
}
