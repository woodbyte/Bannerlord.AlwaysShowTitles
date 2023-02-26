using HarmonyLib;

namespace Bannerlord.AlwaysShowTitles.Patches
{
    internal class CompatibilityPatches
    {
        internal static void Apply(Harmony harmony)
        {
            var prefix = AccessTools.Method(typeof(CompatibilityPatches), nameof(CompatibilityPatches.Prefix));
            var postfix = AccessTools.Method(typeof(CompatibilityPatches), nameof(CompatibilityPatches.Postfix));

            var addMethod = AccessTools.Method("NobleTitles.TitleBehavior:AddTitleToHero");
            var removeMethod = AccessTools.Method("NobleTitles.TitleBehavior:RemoveTitleFromHero");

            if (addMethod != null && removeMethod != null)
            {
                harmony.Patch(addMethod, prefix: new HarmonyMethod(prefix), postfix: new HarmonyMethod(postfix));
                harmony.Patch(removeMethod, prefix: new HarmonyMethod(prefix), postfix: new HarmonyMethod(postfix));
            }

        }

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
