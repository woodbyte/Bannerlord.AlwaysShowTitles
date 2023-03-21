using HarmonyLib;
using TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement.Decisions;
using TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement.Decisions.ItemTypes;

namespace Bannerlord.AlwaysShowTitles.Patches
{
    [HarmonyPatch]
    internal class KingdomPatches
    {
        [HarmonyPatch(typeof(KingdomDecisionsVM))]
        [HarmonyPatch(nameof(KingdomDecisionsVM.RefreshWith))]
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

        [HarmonyPatch(typeof(DecisionItemBaseVM))]
        [HarmonyPatch("RefreshRelationChangeText")]
        class Patch02
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
