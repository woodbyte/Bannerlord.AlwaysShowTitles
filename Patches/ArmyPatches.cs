using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace Bannerlord.AlwaysShowTitles.Patches
{
    [HarmonyPatch]
    internal class ArmyPatches
    {
        [HarmonyPatch(typeof(Army))]
        [HarmonyPatch("OnAfterLoad")]
        class Patch01
        {
            internal static void Postfix(Army __instance)
            {
                __instance.UpdateName();
            }
        }
    }
}
