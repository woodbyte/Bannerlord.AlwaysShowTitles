using Bannerlord.AlwaysShowTitles.Patches;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace Bannerlord.AlwaysShowTitles.Behaviors
{
    internal class AlwaysShowTitlesBehavior : CampaignBehaviorBase
    {
        public override void SyncData(IDataStore dataStore) { }

        public override void RegisterEvents()
        {
            CampaignEvents.OnBeforeSaveEvent.AddNonSerializedListener(this, () =>
            {
                UpdateArmyNames(true);
            });

            CampaignEvents.OnSaveOverEvent.AddNonSerializedListener(this, (cond, str) =>
            {
                UpdateArmyNames();
            });

            CampaignEvents.OnGameLoadFinishedEvent.AddNonSerializedListener(this, () =>
            {
                UpdateArmyNames();
            });
        }

        void UpdateArmyNames(bool disablePatch = false)
        {
            HeroPatches.EnableNamePatch = !disablePatch;

            foreach (MobileParty item in MobileParty.All)
            {
                if (item.Army != null)
                {
                    item.Army.UpdateName();
                }
            }

            HeroPatches.EnableNamePatch = true;
        }
    }
}
