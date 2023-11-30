using BackpackMod.Patches;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class BackpackModBase : BaseUnityPlugin
    {
        private const string modGUID = "Glocean.BackpackMod";
        private const string modName = "BackpackMod";
        private const string modVersion = "1.0.0";
        public static int inventorySize = 4;

        private readonly Harmony harmony = new Harmony(modGUID);

        private static BackpackModBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance = null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Test mod has awoken :)");

            harmony.PatchAll(typeof(BackpackModBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
            harmony.PatchAll(typeof(HUDManagerPatch));
            harmony.PatchAll(typeof(BoomboxItemPatch));
        }

    }
}
