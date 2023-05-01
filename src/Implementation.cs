using MelonLoader;
using UnityEngine;

namespace BedrollTweaker
{
    public class Implementation : MelonMod
    {
        [Obsolete]
        public override void OnApplicationStart()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }
    }
}
