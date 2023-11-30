using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace BackpackMod.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class HUDManagerPatch
    {

        [HarmonyPatch(typeof(HUDManager), "Awake")]
        [HarmonyPostfix]
        public static void InitHUDInventory()
        {

            SetHUDInventory();

        }

        public static void SetHUDInventory()
        {
            var inventorySize = BackpackModBase.inventorySize;

            if ( inventorySize != HUDManager.Instance.itemSlotIcons.Length )
            {
                Image[] itemSlotIconsNew = new Image[inventorySize];
                Image[] itemSlotIconFramesNew = new Image[inventorySize];

                itemSlotIconsNew[0] = HUDManager.Instance.itemSlotIcons[0];
                itemSlotIconsNew[1] = HUDManager.Instance.itemSlotIcons[1];
                itemSlotIconsNew[2] = HUDManager.Instance.itemSlotIcons[2];
                itemSlotIconsNew[3] = HUDManager.Instance.itemSlotIcons[3];

                itemSlotIconFramesNew[0] = HUDManager.Instance.itemSlotIconFrames[0];
                itemSlotIconFramesNew[1] = HUDManager.Instance.itemSlotIconFrames[1];
                itemSlotIconFramesNew[2] = HUDManager.Instance.itemSlotIconFrames[2];
                itemSlotIconFramesNew[3] = HUDManager.Instance.itemSlotIconFrames[3];

                HUDManager.Instance.itemSlotIcons = itemSlotIconsNew;
                HUDManager.Instance.itemSlotIconFrames = itemSlotIconFramesNew;

                Image[] itemSlotIcons = HUDManager.Instance.itemSlotIcons;
                Image[] itemSlotIconFrames = HUDManager.Instance.itemSlotIconFrames;

                float padding = itemSlotIcons[1].transform.position.x - itemSlotIcons[0].transform.position.x;

                for (int i = 4; i < inventorySize; i++)
                {
                    float x = itemSlotIconFrames[i - 1].transform.position.x + padding;
                    itemSlotIconFrames[i] = UnityEngine.Object.Instantiate(itemSlotIconFrames[i - 1], new Vector3(x, itemSlotIconFrames[i - 1].transform.position.y, itemSlotIconFrames[i - 1].transform.position.z), itemSlotIconFrames[0].transform.rotation, itemSlotIconFrames[0].transform.parent);
                    itemSlotIcons[i] = UnityEngine.Object.Instantiate(itemSlotIcons[i - 1], itemSlotIconFrames[i].transform.position, itemSlotIcons[0].transform.rotation, itemSlotIconFrames[i].transform);
                }

                for (int k = 0; k < inventorySize; k++)
                {
                    itemSlotIconFrames[k].transform.position = itemSlotIconFrames[k].transform.position - Vector3.right * (inventorySize - 4) * (padding / 2f);
                }
            }

        }

    }
}
