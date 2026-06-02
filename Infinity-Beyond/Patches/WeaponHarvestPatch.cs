using HarmonyLib;
using Infinity_TestMod.Util;

namespace Infinity_TestMod.Patches
{
    // Weapon harvester. WeaponLoader.GetBundleData reads player.Weapon.Bundle;
    // we catalog it on construction along with PrefabName and ItemType so the
    // spoof can later reproduce the prefab lookup and hold-pose selection.
    [HarmonyPatch(typeof(WeaponLoader), MethodType.Constructor, new System.Type[] { typeof(HumanoidAvatar) })]
    public static class WeaponHarvestPatch
    {
        public static void Postfix(HumanoidAvatar p)
        {
            try
            {
                if (p == null || p.character == null) return;
                EquipItem item = p.character.Weapon;
                if (item == null || item.Bundle == null) return;
                string name = (item as Item)?.Name ?? "";
                ItemCatalog.RecordWeapon(item.ID, name, item.Bundle, item.PrefabName, (int)item.ItemType);
            }
            catch { }
        }
    }
}
