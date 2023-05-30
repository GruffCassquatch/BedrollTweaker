namespace BedrollTweaker
{
    [HarmonyPatch(typeof(GearItem), nameof(GearItem.Deserialize))]
    internal class GEAR_BearskinBedRoll
    {
        private static void Postfix(GearItem __instance)
        {
            if (Utilities.NormalizeName(__instance.name) == "GEAR_BearSkinBedRoll")
            {
                MelonLogger.Msg($"Bearskin Bedroll");
                /*
                GearItem item = Utilities.GetGearItemPrefab("GEAR_BearSkinBedRoll");

                if (Settings.settings.modFunction)
                {
                    if (Settings.settings.tweakBearskinBedroll == Choice.Custom)
                    {
                        item.WeightKG                           = Settings.settings.bearskinBedrollWeight;
                        item.m_Bed.m_WarmthBonusCelsius         = Settings.settings.bearskinBedrollWarmth;
#if DEBUG
                        MelonLogger.Msg($"SETTINGS: tweakBedroll:{Choice.Custom}, m_WarmthBonusCelsius:{Settings.settings.bearskinBedrollWarmth}, WeightKG:{Settings.settings.bearskinBedrollWeight}");
                        MelonLogger.Msg($"MODIFIED: m_WarmthBonusCelsius:{item.m_Bed.m_WarmthBonusCelsius}, WeightKG:{item.WeightKG}");
#endif
                    }
                    if (Settings.settings.bearskinBedrollDecay == Choice.Custom)
                    {
                        item.m_GearItemData.m_DailyHPDecay *= Settings.settings.bearskinBedrollDecayDaily;
                        if (item.m_DegradeOnUse)
                        {
                            item.m_DegradeOnUse.m_DegradeHP *= Settings.settings.bearskinBedrollDecayOnUse;
                        }
#if DEBUG
                        MelonLogger.Msg($"SETTINGS: bedrollDecay:{Choice.Custom}, m_DailyHPDecay:{Settings.settings.bearskinBedrollDecayDaily}, m_DegradeHP:{Settings.settings.bearskinBedrollDecayOnUse}");
                        MelonLogger.Msg($"MODIFIED: m_DailyHPDecay:{item.m_GearItemData.m_DailyHPDecay}, m_DegradeHP:{item.m_DegradeOnUse.m_DegradeHP}");
#endif
                    }
                }
                */
                if (Settings.settings.tweakBearskinBedroll == Choice.Custom)
                {
                    __instance.m_Bed.m_WarmthBonusCelsius = Settings.settings.bearskinBedrollWarmth;
                    __instance.WeightKG = Settings.settings.bearskinBedrollWeight;
                    MelonLogger.Msg("tweakBearskinBedroll:Custom");
                    MelonLogger.Msg($"[SETTING] : bearskinBedrollWarmth:{Settings.settings.bearskinBedrollWarmth},  bearskinBedrollWeight:{Settings.settings.bearskinBedrollWeight}");
                    MelonLogger.Msg($"[ACTUAL]  : bearskinBedrollWarmth:{__instance.m_Bed.m_WarmthBonusCelsius},    bearskinBedrollWeight:{__instance.WeightKG}");
                }
                else if (Settings.settings.bearskinBedrollDecay == Choice.Custom)
                {
                    __instance.m_GearItemData.m_DailyHPDecay = Settings.settings.bearskinBedrollDecayDaily;
                    if (__instance.m_DegradeOnUse)
                    {
                        __instance.m_DegradeOnUse.m_DegradeHP *= Settings.settings.bearskinBedrollDecayOnUse;
                    }
                    MelonLogger.Msg("bearskinBedrollDecay:Custom");
                    MelonLogger.Msg($"[SETTING] : bearskinBedrollDecayDaily:{Settings.settings.bearskinBedrollDecayDaily},  bearskinBedrollDecayOnUse:{Settings.settings.bearskinBedrollDecayOnUse}");
                    MelonLogger.Msg($"[ACTUAL]  : bearskinBedrollDecayDaily:{__instance.m_GearItemData.m_DailyHPDecay},     bearskinBedrollDecayOnUse:{__instance.m_DegradeOnUse.m_DegradeHP}");
                }
            }
        }
    }
}
