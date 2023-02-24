using Bannerlord.AlwaysShowTitles.Behaviors;
using Bannerlord.AlwaysShowTitles.Patches;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.AlwaysShowTitles
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            var harmony = new Harmony("bannerlord.alwayshowtitles");
            harmony.PatchAll();

            CompatibilityPatches.Apply(harmony);
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            if (gameStarterObject is CampaignGameStarter cgs)
            {
                cgs.AddBehavior(new AlwaysShowTitlesBehavior());
            }
        }
    }
}