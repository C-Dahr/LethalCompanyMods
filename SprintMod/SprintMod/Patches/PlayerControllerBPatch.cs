using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SprintMod.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void infiniteSprintPatch(ref float ___sprintMeter, ref float ___sprintMultiplier, ref bool ___isSprinting)
        {
            ___sprintMeter = 1f;
            if (___isSprinting)
            {
                ___sprintMultiplier = Mathf.Lerp(___sprintMultiplier, 10f, Time.deltaTime * 1f);
            }
        }

    }
}
