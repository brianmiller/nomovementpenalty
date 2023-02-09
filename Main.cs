using System.Reflection;
using BepInEx;
using HarmonyLib;


namespace NoMovementPenalty
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        public const string MODNAME = "NoMovementPenalty";
        public const string AUTHOR = "posixone";
        public const string GUID = "posixone_NoMovementPenalty";
        public const string VERSION = "1.0.0";

        private void Awake()
        {
            var harmony = new Harmony(GUID);
            var assembly = Assembly.GetExecutingAssembly();

            harmony.PatchAll(assembly);
            Logger.LogMessage($"{AUTHOR}'s {MODNAME} (v{VERSION}) has started");
        }

        [HarmonyPatch(typeof(Player), "UpdateMovementModifier")]
        public class EquippedArmorDoesntAffectMovementSpeedMod
        {
            public static bool Prefix(ref float ___m_equipmentMovementModifier)
            {
                ___m_equipmentMovementModifier = 0.0f;
                return false;
            }
        }
    }
}
