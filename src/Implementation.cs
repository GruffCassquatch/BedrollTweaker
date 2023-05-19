namespace BedrollTweaker
{
    public class Implementation : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }
    }
}
