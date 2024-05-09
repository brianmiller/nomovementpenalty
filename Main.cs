using System.Reflection;
using BepInEx;
using HarmonyLib;
using BepInEx.Configuration;


namespace NoMovementPenalty
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        public const string MODNAME = "NoMovementPenalty";
        public const string AUTHOR = "posixone";
        public const string GUID = "posixone_NoMovementPenalty";
        public const string VERSION = "1.0.4";

        public static ConfigEntry<bool> modEnable;
        public static ConfigEntry<bool> rightItemEnable;
        public static ConfigEntry<bool> leftItemEnable;
        public static ConfigEntry<bool> helmetItemEnable;
        public static ConfigEntry<bool> chestItemEnable;
        public static ConfigEntry<bool> legItemEnable;
        public static ConfigEntry<bool> shoulderItemEnable;
        public static ConfigEntry<bool> utilityItemEnable;

        private void Awake()
        {

            //global
            modEnable = Config.Bind(new ConfigDefinition("1-Global", "modEnable"), true, new ConfigDescription("Set this to true to enable and false to disable this mod."));

            //mod toggles
            rightItemEnable = Config.Bind(new ConfigDefinition("2-Toggles", "rightItemEnable"), true, new ConfigDescription("Set this to true to enable NoMovementPenalty for the equipped right-handed item."));
            leftItemEnable = Config.Bind(new ConfigDefinition("2-Toggles", "leftItemEnable"), true, new ConfigDescription("Set this to true to enable NoMovementPenalty for the equipped left-handed item."));
            helmetItemEnable = Config.Bind(new ConfigDefinition("2-Toggles", "helmetItemEnable"), true, new ConfigDescription("Set this to true to enable NoMovementPenalty for the equipped helmet item."));
            chestItemEnable = Config.Bind(new ConfigDefinition("2-Toggles", "chestItemEnable"), true, new ConfigDescription("Set this to true to enable NoMovementPenalty for the equipped chest item."));
            legItemEnable = Config.Bind(new ConfigDefinition("2-Toggles", "legItemEnable"), true, new ConfigDescription("Set this to true to enable NoMovementPenalty for the equipped leg item."));
            shoulderItemEnable = Config.Bind(new ConfigDefinition("2-Toggles", "shoulderItemEnable"), true, new ConfigDescription("Set this to true to enable NoMovementPenalty for the equipped shoulder item."));
            utilityItemEnable = Config.Bind(new ConfigDefinition("2-Toggles", "utilityItemEnable"), true, new ConfigDescription("Set this to true to enable NoMovementPenalty for the equipped utility item."));
            
            var harmony = new Harmony(GUID);
            var assembly = Assembly.GetExecutingAssembly();

            //if this mod isn't enabled, don't run
            if (!modEnable.Value)
            {
                return;
            }

            harmony.PatchAll(assembly);

        }

        [HarmonyPatch(typeof(Player), "UpdateModifiers")]
        public class EquippedArmorDoesntAffectMovementSpeedMod
        {
            public static bool Prefix
                (ref float ___m_equipmentModifierValues,
                ref ItemDrop.ItemData ___m_rightItem,
                ref ItemDrop.ItemData ___m_leftItem,
                ref ItemDrop.ItemData ___m_helmetItem,
                ref ItemDrop.ItemData ___m_chestItem,                          
                ref ItemDrop.ItemData ___m_legItem,
                ref ItemDrop.ItemData ___m_shoulderItem,
                ref ItemDrop.ItemData ___m_utilityItem)
            {
                if ((___m_rightItem != null) && (rightItemEnable.Value))
                {
                    if (___m_rightItem.m_shared.m_movementModifier < 0.0f)
                    {
                        ___m_rightItem.m_shared.m_movementModifier = 0.000000000000000001f;
                    }
                }

                if ((___m_leftItem != null) && (leftItemEnable.Value))
                {
                    if (___m_leftItem.m_shared.m_movementModifier < 0.0f)
                    {
                        ___m_leftItem.m_shared.m_movementModifier = 0.000000000000000001f;
                    }
                }

                if ((___m_helmetItem != null) && (helmetItemEnable.Value))
                {
                    if (___m_helmetItem.m_shared.m_movementModifier < 0.0f)
                    {
                        ___m_helmetItem.m_shared.m_movementModifier = 0.000000000000000001f;
                    }
                }

                if ((___m_chestItem != null) && (chestItemEnable.Value))
                {
                    if (___m_chestItem.m_shared.m_movementModifier < 0.0f)
                    {
                        ___m_chestItem.m_shared.m_movementModifier = 0.000000000000000001f;
                    }
                }

                if ((___m_legItem != null) && (legItemEnable.Value))
                {
                    if (___m_legItem.m_shared.m_movementModifier < 0.0f)
                    {
                        ___m_legItem.m_shared.m_movementModifier = 0.000000000000000001f;
                    }
                }

                if ((___m_shoulderItem != null) && (shoulderItemEnable.Value))
                {
                    if (___m_shoulderItem.m_shared.m_movementModifier < 0.0f)
                    {
                        ___m_shoulderItem.m_shared.m_movementModifier = 0.000000000000000001f;
                    }
                }

                if ((___m_utilityItem != null) && (utilityItemEnable.Value))
                {
                    if (___m_utilityItem.m_shared.m_movementModifier < 0.0f)
                    {
                        ___m_utilityItem.m_shared.m_movementModifier = 0.000000000000000001f;
                    }
                }

                return true;   
                
            }
        }
    }
}
