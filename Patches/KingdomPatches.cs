using HarmonyLib;
using TaleWorlds.CampaignSystem.Election;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement.Decisions;
using TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement.Decisions.ItemTypes;
using TaleWorlds.Localization;
using System;

namespace Bannerlord.AlwaysShowTitles.Patches
{
    [HarmonyPatch]
    internal class KingdomPatches
    {
        [HarmonyPatch(typeof(DecisionSupporterVM))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] { typeof(TextObject), typeof(string), typeof(Clan), typeof(Supporter.SupportWeights) })]
        class Patch01
        {
            internal static void Prefix(ref TextObject name, string imagePath, Clan clan, Supporter.SupportWeights weight)
            {
                HeroPatches.EnableNamePatch = false;

                name = clan.Leader.Name;
            }

            internal static void Postfix(TextObject name, string imagePath, Clan clan, Supporter.SupportWeights weight)
            {
                HeroPatches.EnableNamePatch = true;
            }
        }

        [HarmonyPatch(typeof(DecisionItemBaseVM))]
        [HarmonyPatch("RefreshRelationChangeText")]
        class Patch02
        {
            internal static void Prefix(ref bool __state)
            {
                if (!HeroPatches.EnableLordTitlePatch)
                    __state = true;
                else
                    HeroPatches.EnableLordTitlePatch = false;
            }

            internal static void Postfix(bool __state)
            {
                if (!__state)
                    HeroPatches.EnableLordTitlePatch = true;
            }
        }

        [HarmonyPatch(typeof(DeclareWarDecisionItemVM))]
        [HarmonyPatch("InitValues")]
        class Patch03
        {
            internal static void Prefix()
            {
                HeroPatches.EnableLordTitlePatch = false;
            }

            internal static void Postfix()
            {
                HeroPatches.EnableLordTitlePatch = true;
            }
        }

        [HarmonyPatch(typeof(ExpelClanDecisionItemVM))]
        [HarmonyPatch("InitValues")]
        class Patch04
        {
            internal static void Prefix()
            {
                HeroPatches.EnableLordTitlePatch = false;
            }

            internal static void Postfix()
            {
                HeroPatches.EnableLordTitlePatch = true;
            }
        }

        [HarmonyPatch(typeof(KingSelectionDecisionItemVM))]
        [HarmonyPatch("InitValues")]
        class Patch05
        {
            internal static void Prefix()
            {
                HeroPatches.EnableLordTitlePatch = false;
            }

            internal static void Postfix()
            {
                HeroPatches.EnableLordTitlePatch = true;
            }
        }

        [HarmonyPatch(typeof(MakePeaceDecisionItemVM))]
        [HarmonyPatch("InitValues")]
        class Patch06
        {
            internal static void Prefix()
            {
                HeroPatches.EnableLordTitlePatch = false;
            }

            internal static void Postfix()
            {
                HeroPatches.EnableLordTitlePatch = true;
            }
        }

        [HarmonyPatch(typeof(PolicyDecisionItemVM))]
        [HarmonyPatch("InitValues")]
        class Patch07
        {
            internal static void Prefix()
            {
                HeroPatches.EnableLordTitlePatch = false;
            }

            internal static void Postfix()
            {
                HeroPatches.EnableLordTitlePatch = true;
            }
        }

        [HarmonyPatch(typeof(SettlementDecisionItemVM))]
        [HarmonyPatch("InitValues")]
        class Patch08
        {
            internal static void Prefix()
            {
                HeroPatches.EnableLordTitlePatch = false;
            }

            internal static void Postfix()
            {
                HeroPatches.EnableLordTitlePatch = true;
            }
        }
    }
}
