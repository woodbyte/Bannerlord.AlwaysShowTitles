using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.PerCampaign;

namespace Bannerlord.AlwaysShowTitles
{
    internal sealed class Settings : AttributePerCampaignSettings<Settings>
    {
        public override string Id => "AlwaysShowTitles";
        public override string FolderName => "AlwaysShowTitles";
        public override string DisplayName => $"Always Show Titles {typeof(Settings).Assembly.GetName().Version.ToString(3)}";

        [SettingPropertyBool("Disable the Mod", RequireRestart = false, Order = 1, HintText = "Enable and save before uninstalling the mod.")]
        [SettingPropertyGroup("Uninstall", GroupOrder = 1)]
        public bool Disable { get; set; } = false;
    }
}
