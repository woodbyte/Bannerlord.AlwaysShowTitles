using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Engine.Options;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.AlwaysShowTitles
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            var harmony = new Harmony("bannerlord.alwayshowtitles");
            harmony.PatchAll();

            NativeOptions.OnNativeOptionsApplied += UpdateArmyNames;
        }

        private void UpdateArmyNames()
        {
            if (Campaign.Current == null) return;

            foreach (MobileParty item in MobileParty.All)
            {
                if (item.Army != null)
                {
                    item.Army.UpdateName();
                }
            }
        }
    }
}