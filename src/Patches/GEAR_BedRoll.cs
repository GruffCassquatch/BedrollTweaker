namespace BedrollTweaker
{
    [HarmonyPatch(typeof(GearItem), nameof(GearItem.Deserialize))]
    internal class GEAR_BedRoll
    {
        private static void Postfix(GearItem __instance)
        {
            if (Utilities.NormalizeName(__instance.name) == "GEAR_BedRoll")
            {
                MelonLogger.Msg($"Normal Bedroll");
                /*
                GearItem item = Utilities.GetGearItemPrefab("GEAR_BedRoll");

                if (Settings.settings.tweakBedroll == Choice.Custom)
                {
                    item.m_Bed.m_WarmthBonusCelsius = Settings.settings.bedrollWarmth;
                    item.WeightKG = Settings.settings.bedrollWeight;
#if DEBUG
                    MelonLogger.Msg($"SETTINGS: tweakBedroll:{Choice.Custom}, m_WarmthBonusCelsius:{Settings.settings.bedrollWarmth}, WeightKG:{Settings.settings.bedrollWeight}");
                    MelonLogger.Msg($"MODIFIED: m_WarmthBonusCelsius:{item.m_Bed.m_WarmthBonusCelsius}, WeightKG:{item.WeightKG}");
#endif
                }
                if (Settings.settings.bedrollDecay == Choice.Custom)
                {
                    item.m_GearItemData.m_DailyHPDecay *= Settings.settings.bedrollDecayDaily;
                    if (__instance.m_DegradeOnUse)
                    {
                        item.m_DegradeOnUse.m_DegradeHP *= Settings.settings.bedrollDecayOnUse;
                    }
#if DEBUG
                    MelonLogger.Msg($"SETTINGS: bedrollDecay:{Choice.Custom}, m_DailyHPDecay:{Settings.settings.bedrollDecayDaily}, m_DegradeHP:{Settings.settings.bedrollDecayOnUse}");
                    MelonLogger.Msg($"MODIFIED: m_DailyHPDecay:{item.m_GearItemData.m_DailyHPDecay}, m_DegradeHP:{item.m_DegradeOnUse.m_DegradeHP}");
#endif
                }
                */
                if (Settings.settings.tweakBedroll == Choice.Custom)
                {
                    __instance.m_Bed.m_WarmthBonusCelsius = Settings.settings.bedrollWarmth;
                    __instance.WeightKG = Settings.settings.bedrollWeight;
                    MelonLogger.Msg("tweakBedroll:Custom");
                    MelonLogger.Msg($"[SETTING] : bedrollWarmth:{Settings.settings.bedrollWarmth}, bedrollWeight:{Settings.settings.bedrollWeight}");
                    MelonLogger.Msg($"[ACTUAL]  : bedrollWarmth:{__instance.m_Bed.m_WarmthBonusCelsius}, bedrollWeight:{__instance.WeightKG}");
                }
                else if (Settings.settings.bedrollDecay == Choice.Custom)
                {
                    __instance.m_GearItemData.m_DailyHPDecay = Settings.settings.bedrollDecayDaily;
                    if (__instance.m_DegradeOnUse)
                    {
                        __instance.m_DegradeOnUse.m_DegradeHP *= Settings.settings.bedrollDecayOnUse;
                    }
                    MelonLogger.Msg("bedrollDecay:Custom");
                    MelonLogger.Msg($"[SETTING] : bedrollDecayDaily:{Settings.settings.bedrollDecayDaily}, bedrollDecayOnUse:{Settings.settings.bedrollDecayOnUse}");
                    MelonLogger.Msg($"[ACTUAL]  : bedrollDecayDaily:{__instance.m_GearItemData.m_DailyHPDecay}, bedrollDecayOnUse:{__instance.m_DegradeOnUse.m_DegradeHP}");
                }
            }
        }
    }
}
