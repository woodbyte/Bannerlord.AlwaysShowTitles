using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace Bannerlord.AlwaysShowTitles.Patches
{
    [HarmonyPatch]
    internal class HeroPatches
    {
        internal static bool EnableNamePatch { get; set; } = true;
        internal static Hero? NamePatchExcludedHero { get; set; } = null;

        [HarmonyPatch(typeof(Hero))]
        [HarmonyPatch(nameof(Hero.Name), MethodType.Getter)]
        class Patch01
        {
            static AccessTools.FieldRef<TextObject, string> value =
                AccessTools.FieldRefAccess<TextObject, string>("Value");

            internal static void Postfix(Hero __instance, ref TextObject __result)
            {
                if (!EnableNamePatch) return;

                Hero hero = __instance;

                if (hero == NamePatchExcludedHero) return;

                // Hide wanderer titles after they become lords
                var resultValue = value(__result);
                if (resultValue.Contains("{FIRSTNAME}") && !hero.IsWanderer && hero.IsLord)
                {
                    var firstName = __result.CopyTextObject();
                    value(firstName) = "{FIRSTNAME}";
                    firstName.CacheTokens();
                    __result = firstName;
                }

                // Always show noble titles
                if (hero.IsLord && !hero.IsMinorFactionHero && hero.Clan?.Leader == hero && hero.Clan?.Kingdom != null && hero.Clan?.IsUnderMercenaryService == false)
                {
                    string stringId = hero.MapFaction.Culture.StringId;
                    GameTexts.TryGetText("str_faction_noble_name_with_title", out var text, stringId);

                    if (hero.Clan.Kingdom.Leader == hero)
                    {
                        text = GameTexts.FindText("str_faction_ruler_name_with_title", stringId);
                    }

                    TextObject props = new TextObject();
                    props.SetTextVariable("NAME", __result.ToString());
                    props.SetTextVariable("GENDER", hero.CharacterObject.IsFemale ? 1 : 0);

                    text.SetTextVariable("RULER", props);

                    __result = text;
                }
            }
        }

        [HarmonyPatch(typeof(Hero))]
        [HarmonyPatch(nameof(Hero.SetHeroEncyclopediaTextAndLinks))]
        class Patch02
        {
            internal static void Prefix(Hero o)
            {
                NamePatchExcludedHero = o;
            }

            internal static void Postfix(Hero o)
            {
                NamePatchExcludedHero = null;
            }
        }
    }
}
