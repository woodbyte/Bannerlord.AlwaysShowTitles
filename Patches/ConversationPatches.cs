using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.ViewModelCollection.Conversation;

namespace Bannerlord.AlwaysShowTitles.Patches
{
    [HarmonyPatch]
    internal class ConversationPatches
    {
        [HarmonyPatch(typeof(MissionConversationVM))]
        [HarmonyPatch(nameof(MissionConversationVM.Refresh))]
        class Patch01
        {
            internal static void Prefix(MissionConversationVM __instance)
            {
                HeroPatches.NamePatchExcludedHero = Campaign.Current.ConversationManager.OneToOneConversationHero;
            }

            internal static void Postfix()
            {
                HeroPatches.NamePatchExcludedHero = null;
            }
        }
    }
}
