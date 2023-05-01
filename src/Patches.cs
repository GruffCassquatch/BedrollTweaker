using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Gear;
using UnityEngine;

namespace BedrollTweaker
{
    class Patches
    {
        [HarmonyPatch(typeof(Bed), "GetWarmthBonusCelsius")]
        private static class BedrollWarmthStackerBonus
        {
            internal static void Postfix(ref float __result)
            {
                if (Settings.settings.modFunction && Settings.settings.bedrollsStack)
                {
                    List<float> allBedrolls = new List<float>();
                    float bedrollBonus = 0f;

                    foreach (GearItemObject gearItemObject in GameManager.GetInventoryComponent().m_Items)
                    {
                        GearItem gearItem = gearItemObject;
                        if (gearItem)
                        {
                            Bed bed = gearItem.m_Bed;
                            if (bed)
                            {
                                if (bed.m_Bedroll)
                                {
                                    allBedrolls.Add(bed.m_WarmthBonusCelsius * bed.m_Bedroll.GetNormalizedCondition());
                                    bedrollBonus += (bed.m_WarmthBonusCelsius * bed.m_Bedroll.GetNormalizedCondition());
                                }
                            }
                        }
                    }

                    if (Settings.settings.maxBedrolls || Settings.settings.diminishingBonus || Settings.settings.partialBonus)
                    {
                        allBedrolls.Sort();
                        allBedrolls.Reverse();

                        bedrollBonus = 0f;

                        if (Settings.settings.maxBedrolls)
                        {
                            allBedrolls = allBedrolls.Take(Settings.settings.maxBedrollsNumber).ToList();
                        }
                        if (!Settings.settings.diminishingBonus && !Settings.settings.partialBonus)
                        {
                            foreach (float originalValue in allBedrolls)
                            {
                                bedrollBonus += originalValue;
                            }
                        }
                        if (Settings.settings.partialBonus)
                        {
                            List<float> partialBonus = new List<float>();
                            foreach (float originalValue in allBedrolls)
                            {
                                partialBonus.Add(originalValue * Settings.settings.partialRate);
                                bedrollBonus += originalValue * Settings.settings.partialRate;
                            }
                            allBedrolls = partialBonus;
                        }
                        if (Settings.settings.diminishingBonus)
                        {
                            bedrollBonus = 0f;
                            float multiplier = 1 - Settings.settings.diminishingRate;
                            foreach (float originalValue in allBedrolls)
                            {
                                if (multiplier <= 0) break;
                                bedrollBonus += (originalValue * multiplier);
                                multiplier = multiplier - Settings.settings.diminishingRate;
                            }
                        }
                    }

                    if (Settings.settings.capWarmthBonus)
                    {
                        bedrollBonus = Math.Min(bedrollBonus, Settings.settings.warmthBonusCap);
                    }
                    __result += bedrollBonus;
                }
            }
        }

        [HarmonyPatch(typeof(GearItem), "Awake")]
        private static class UpdateBedrollStats
        {
            internal static void Postfix(GearItem __instance)
            {
                if (Settings.settings.modFunction) 
                {
                    if (__instance.name.Contains("GEAR_BedRoll"))
                    {
                        if (Settings.settings.tweakBedroll == Choice.Custom) 
                        {
                            __instance.m_Bed.m_WarmthBonusCelsius = Settings.settings.bedrollWarmth;
                            __instance.WeightKG = Settings.settings.bedrollWeight; 
                        }
                        if (Settings.settings.bedrollDecay == Choice.Custom)
                        {
                            //MelonLogger.Msg(__instance.name.ToString() + "ORIGINAL DailyHPDecay = " + __instance.m_DailyHPDecay.ToString());
                            __instance.m_GearItemData.m_DailyHPDecay *= Settings.settings.bedrollDecayDaily;
                            //MelonLogger.Msg(__instance.name.ToString() + "NEW DailyHPDecay = " + __instance.m_DailyHPDecay.ToString());

                            if (__instance.m_DegradeOnUse)
                            {
                                //MelonLogger.Msg(__instance.name.ToString() + "ORIGINAL DegradeOnUse = " + __instance.m_DegradeOnUse.m_DegradeHP.ToString());
                                __instance.m_DegradeOnUse.m_DegradeHP *= Settings.settings.bedrollDecayOnUse;
                                //MelonLogger.Msg(__instance.name.ToString() + "NEW DegradeOnUse = " + __instance.m_DegradeOnUse.m_DegradeHP.ToString());
                            }
                        }
                    }
                    else if (__instance.name.Contains("GEAR_BearskinBedRoll"))
                    {
                        if (Settings.settings.tweakBearskinBedroll == Choice.Custom)
                        {
                            __instance.m_Bed.m_WarmthBonusCelsius = Settings.settings.bearskinBedrollWarmth;
                            __instance.WeightKG = Settings.settings.bearskinBedrollWeight;
                        }
                        if (Settings.settings.bearskinBedrollDecay == Choice.Custom)
                        {
                            //MelonLogger.Msg(__instance.name.ToString() + "ORIGINAL DailyHPDecay = " + __instance.m_DailyHPDecay.ToString());
                            __instance.m_GearItemData.m_DailyHPDecay *= Settings.settings.bearskinBedrollDecayDaily;
                            //MelonLogger.Msg(__instance.name.ToString() + "NEW DailyHPDecay = " + __instance.m_DailyHPDecay.ToString());

                            if (__instance.m_DegradeOnUse)
                            {
                                //MelonLogger.Msg(__instance.name.ToString() + "ORIGINAL DegradeOnUse = " + __instance.m_DegradeOnUse.m_DegradeHP.ToString());
                                __instance.m_DegradeOnUse.m_DegradeHP *= Settings.settings.bearskinBedrollDecayOnUse;
                                //MelonLogger.Msg(__instance.name.ToString() + "NEW DegradeOnUse = " + __instance.m_DegradeOnUse.m_DegradeHP.ToString());
                            }
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(GameManager), "Awake", null)]
        private static class AdjustBearskinBedrollPrefab
        {
            private static void Postfix()
            {
                if (Settings.settings.modFunction && Settings.settings.tweakBearskinBedroll == Choice.Custom)
                {
                    Settings.settings.ChangePrefabs();
                }
            }
        }
        public static void ChangeBearskinBedrollPrefab()
        {
            GearItem item = GetGearItemPrefab("GEAR_BearSkinBedRoll");
            if (item == null) return;
            item.WeightKG = Settings.settings.bearskinBedrollWeight;
        }

        private static GearItem GetGearItemPrefab(string name) => Resources.Load(name).Cast<GameObject>().GetComponent<GearItem>();
    }
}