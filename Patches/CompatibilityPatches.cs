using HarmonyLib;
using System.Reflection;

namespace Bannerlord.AlwaysShowTitles.Patches
{
    internal class CompatibilityPatches
    {
        internal static void Apply(Harmony harmony)
        {
            var prefix = AccessTools.Method(typeof(CompatibilityPatches), nameof(CompatibilityPatches.Prefix));
            var postfix = AccessTools.Method(typeof(CompatibilityPatches), nameof(CompatibilityPatches.Postfix));

            TryPatchMethod(harmony, "NobleTitles.TitleBehavior:AddTitleToHero", prefix, postfix);
            TryPatchMethod(harmony, "NobleTitles.TitleBehavior:RemoveTitleFromHero", prefix, postfix);

            TryPatchMethod(harmony, "CharacterManager.GuiManager:ExecuteLoadCharacter", prefix, postfix);
            TryPatchMethod(harmony, "CharacterManager.GuiManager:ExecuteSaveCharacter", prefix, postfix);
            TryPatchMethod(harmony, "CharacterManager.ConsoleManager:SaveCharacter", prefix, postfix);
            TryPatchMethod(harmony, "CharacterManager.ConsoleManager:LoadCharacter", prefix, postfix);
            TryPatchMethod(harmony, "CharacterManager.ConsoleManager:LoadAllCompanions", prefix, postfix);
            TryPatchMethod(harmony, "CharacterManager.ConsoleManager:PointReseter", prefix, postfix);
            TryPatchMethod(harmony, "CharacterManager.ConsoleManager:PointReseterFull", prefix, postfix);
            TryPatchMethod(harmony, "CharacterManager.ConsoleManager:GodCharacter", prefix, postfix);
            TryPatchMethod(harmony, "CharacterManager.ConsoleManager:GodForAll", prefix, postfix);
            TryPatchMethod(harmony, "CharacterManager.ConsoleManager:rename", prefix, postfix);
        }

        internal static void Prefix()
        {
            HeroPatches.EnableNamePatch = false;
        }

        internal static void Postfix()
        {
            HeroPatches.EnableNamePatch = true;
        }

        internal static bool TryPatchMethod(Harmony harmony, string typeColonName, MethodInfo prefix, MethodInfo postfix)
        {
            var method = AccessTools.Method(typeColonName);

            if (method != null)
            {
                harmony.Patch(method, prefix: new HarmonyMethod(prefix), postfix: new HarmonyMethod(postfix));
                return true;
            }

            return false;
        }
    }
}
