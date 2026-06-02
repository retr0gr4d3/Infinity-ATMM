using HarmonyLib;
using Infinity_TestMod.Util;

namespace Infinity_TestMod.Patches
{
    // Pet harvester. PetLoader.LoadItem reads player.Pet.{Bundle, PrefabName,
    // Scale, OffsetX, OffsetY} directly into BundlePrefabLoader, so the spoof
    // needs all of those to reproduce the load. Capture them on ctor.
    [HarmonyPatch(typeof(PetLoader), MethodType.Constructor, new System.Type[] { typeof(HumanoidAvatar) })]
    public static class PetHarvestPatch
    {
        public static void Postfix(HumanoidAvatar p)
        {
            try
            {
                if (p == null || p.character == null) return;
                EquipItem item = p.character.Pet;
                if (item == null || item.Bundle == null) return;
                string name = (item as Item)?.Name ?? "";
                ItemCatalog.RecordPet(item.ID, name, item.Bundle, item.PrefabName,
                                      item.Scale, item.OffsetX, item.OffsetY);
            }
            catch { }
        }
    }
}
