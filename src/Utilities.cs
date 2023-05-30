namespace BedrollTweaker
{
    internal class Utilities
    {
        internal static List<float> lBedRolls = new();
        internal static float BedRollBonus = 0f;
        public static string? NormalizeName(string name)
        {
            if (name == null)
            {
                return null;
            }
            else
            {
                return name.Replace("(Clone)", "").Trim();
            }
        }
        public static GearItem GetGearItemPrefab(string name) => GearItem.LoadGearItemPrefab(name).GetComponent<GearItem>();
    }
}
