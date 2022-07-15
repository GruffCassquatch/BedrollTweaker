using System.Reflection;
using ModSettings;

namespace BedrollTweaker
{
    class BedrollTweakerSettings : JsonModSettings
    {
        [Section("Enable Mod")]
        [Name("Enable Mod")]
        [Description("YES: The mod is enabled. NO: The mod is disabled.")]
        public bool modFunction = false;

        [Section("Tweak Bedroll Weight & Warmth")]
        [Name("Tweak Bedroll Weight & Warmth")]
        [Description("YES: Show settings for bedroll Weight and Warmth. NO: Unchanged.")]
        public bool tweakBedroll = false;

        [Section("Bedroll")]
        [Name("Warmth Bonus")]
        [Description("Maximum warmth bonus provided by standard bedroll.\nGame Default is 5°C.")]
        [Slider(1f, 20f, 39, NumberFormat = "{0:0.##}°C")]
        public float bedrollWarmth = 5f;

        [Name("Weight")]
        [Description("Weight of standard bedroll.\nGame Default is 1kg.")]
        [Slider(0.25f, 5f, 20, NumberFormat = "{0:0.##}kg")]
        public float bedrollWeight = 1f;

        [Section("Tweak Bearskin Bedroll Weight & Warmth")]
        [Name("Tweak Bearskin Bedroll Weight & Warmth")]
        [Description("YES: Show settings for bedroll Weight and Warmth. NO: Unchanged.")]
        public bool tweakBearskinBedroll = false;

        [Section("Bearskin Bedroll")]
        [Name("Warmth Bonus")]
        [Description("Maximum warmth bonus provided by bearskin bedroll.\nGame Default is 12°C.")]
        [Slider(1f, 20f, 39, NumberFormat = "{0:0.##}°C")]
        public float bearskinBedrollWarmth = 12f;

        [Name("Weight")]
        [Description("Weight of bearskin bedroll.\nGame Default is 3kg.")]
        [Slider(0.25f, 10f, 40, NumberFormat = "{0:0.##}kg")]
        public float bearskinBedrollWeight = 3f;


        [Section("Bedroll Warmth Stacks")]
        [Name("Bedroll Warmth Stacks")]
        [Description("NO: Game Default.\nYES: Additional bedrolls in your inventory will provide extra warmth.")]
        public bool bedrollsStack = false;

        [Name("Cap number of Bedrolls")]
        [Description("NO: Every bedroll in your inventory will provide extra warmth.\nYES: Set the maximum number of bedrolls that can add bonus warmth.")]
        public bool maxBedrolls = false;

        [Name("     Maximum Number:")]
        [Slider(1, 100)]
        [Description("Set the maximum number of bedrolls that can provide warmth bonus.")]
        public int maxBedrollsNumber = 1;

        [Name("Cap Total Warmth Bonus")]
        [Description("NO: There is no cap on the total extra warmth from additional bedrolls.\nYES: Set the maximum total extra warmth provided by additional bedrolls.")]
        public bool capWarmthBonus = false;

        [Name("     Maximum Total Warmth Bonus:")]
        [Slider(1f, 100f, 199, NumberFormat = "{0:0.##}°C")]
        [Description("Set the maximum total warmth bonus from all extra bedrolls.")]
        public float warmthBonusCap = 10f;

        [Name("Partial Warmth Bonus")]
        [Description("NO: Each bedroll provides its full warmth bonus.\nYES: Each extra bedroll provides a % of extra warmth.")]
        public bool partialBonus = false;

        [Name("     Partial Warmth Value:")]
        [Description("Each extra bedroll will provide this % warmth.\nE.g. if set to 50%: 1st extra bedroll provides 50% warmth, 2nd 50% warmth, 3rd 50% warmth etc.\nApplied BEFORE Diminishing Warmth is caluculated.")]
        [Slider(0.01f, 0.99f, 99, NumberFormat = "{0:P0}")]
        public float partialRate = 0.5f;

        [Name("Diminishing Warmth Bonus")]
        [Description("NO: Each bedroll provides its full warmth bonus.\nYES: Each extra bedroll provides progressively less extra warmth.")]
        public bool diminishingBonus = false;

        [Name("     Diminishing Rate:")]
        [Description("Each extra bedroll will provide this % LESS warmth.\nE.g. if set to 10%: 1st extra bedroll provides 90% warmth, 2nd 80% warmth, 3rd 70% warmth etc.\nApplied AFTER Partial Warmth is caluclated.")]
        [Slider(0.01f, 0.99f, 99, NumberFormat = "{0:P0}")]
        public float diminishingRate = 0.1f;


        protected override void OnChange(FieldInfo field, object oldValue, object newValue)
        {
            if (field.Name == nameof(modFunction) ||
                field.Name == nameof(tweakBedroll) ||
                field.Name == nameof(tweakBearskinBedroll) ||
                field.Name == nameof(bedrollsStack) ||
                field.Name == nameof(maxBedrolls) ||
                field.Name == nameof(capWarmthBonus) ||
                field.Name == nameof(diminishingBonus) ||
                field.Name == nameof(partialBonus))

            {
                RefreshFields();
            }
        }

        internal void RefreshFields()
        {
            SetFieldVisible(nameof(tweakBedroll), Settings.settings.modFunction);
            SetFieldVisible(nameof(bedrollWarmth), Settings.settings.modFunction && Settings.settings.tweakBedroll);
            SetFieldVisible(nameof(bedrollWeight), Settings.settings.modFunction && Settings.settings.tweakBedroll);
            SetFieldVisible(nameof(tweakBearskinBedroll), Settings.settings.modFunction);
            SetFieldVisible(nameof(bearskinBedrollWarmth), Settings.settings.modFunction && Settings.settings.tweakBearskinBedroll);
            SetFieldVisible(nameof(bearskinBedrollWeight), Settings.settings.modFunction && Settings.settings.tweakBearskinBedroll);
            SetFieldVisible(nameof(bedrollsStack), Settings.settings.modFunction);
            SetFieldVisible(nameof(maxBedrolls), Settings.settings.modFunction && Settings.settings.bedrollsStack);
            SetFieldVisible(nameof(maxBedrollsNumber), Settings.settings.modFunction && Settings.settings.maxBedrolls && Settings.settings.bedrollsStack);
            SetFieldVisible(nameof(capWarmthBonus), Settings.settings.modFunction && Settings.settings.bedrollsStack);
            SetFieldVisible(nameof(warmthBonusCap), Settings.settings.modFunction && Settings.settings.capWarmthBonus && Settings.settings.bedrollsStack);
            SetFieldVisible(nameof(diminishingBonus), Settings.settings.modFunction && Settings.settings.bedrollsStack);
            SetFieldVisible(nameof(diminishingRate), Settings.settings.modFunction && Settings.settings.diminishingBonus && Settings.settings.bedrollsStack);
            SetFieldVisible(nameof(partialBonus), Settings.settings.modFunction && Settings.settings.bedrollsStack);
            SetFieldVisible(nameof(partialRate), Settings.settings.modFunction && Settings.settings.bedrollsStack && Settings.settings.partialBonus);
        }

        protected override void OnConfirm()
        {
            base.OnConfirm();
            ChangePrefabs();
        }
        internal void ChangePrefabs()
        {
            if (Settings.settings.modFunction && Settings.settings.tweakBearskinBedroll) 
            {
                Patches.ChangeBearskinBedrollPrefab(); 
            }
        }
    }

    internal static class Settings
    {
        public static BedrollTweakerSettings settings;
        public static void OnLoad()
        {
            settings = new BedrollTweakerSettings();
            settings.AddToModSettings("Bedroll Tweaker");
            settings.RefreshFields();
        }
    }
}
