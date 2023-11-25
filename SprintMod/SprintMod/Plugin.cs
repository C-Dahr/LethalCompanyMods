using SprintMod.Patches;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class SprintModBase : BaseUnityPlugin
    {
        private const string modGUID = "Glocean.SprintMod";
        private const string modName = "SprintMod";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static SprintModBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance = null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Test mod has awoken :)");

            harmony.PatchAll(typeof(SprintModBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }

    }
}
