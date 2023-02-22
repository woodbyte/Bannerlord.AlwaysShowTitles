using HarmonyLib;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.Categories;

namespace Bannerlord.AlwaysShowTitles.Patches
{
    [HarmonyPatch]
    internal class ClanPatches
    {
        [HarmonyPatch(typeof(ClanMembersVM))]
        [HarmonyPatch(nameof(ClanMembersVM.RefreshValues))]
        class Patch01
        {
            internal static void Prefix()
            {
                HeroPatches.EnableNamePatch = false;
            }

            internal static void Postfix()
            {
                HeroPatches.EnableNamePatch = true;
            }
        }
    }
}
