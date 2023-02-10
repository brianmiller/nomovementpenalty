using System.Linq.Expressions;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace NoMovementPenalty
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        public const string MODNAME = "NoMovementPenalty";
        public const string AUTHOR = "posixone";
        public const string GUID = "posixone_NoMovementPenalty";
        public const string VERSION = "1.0.1";

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
            public static bool Prefix
                (ref float ___m_equipmentMovementModifier,
                ref ItemDrop.ItemData ___m_rightItem,
                ref ItemDrop.ItemData ___m_leftItem,
                ref ItemDrop.ItemData ___m_utilityItem,
                ref ItemDrop.ItemData ___m_chestItem,
                ref ItemDrop.ItemData ___m_shoulderItem,
                ref ItemDrop.ItemData ___m_helmetItem,
                ref ItemDrop.ItemData ___m_legItem)
            {
                try
                {
                    if (___m_rightItem.m_shared.m_movementModifier > 0)
                    {
                        ___m_equipmentMovementModifier += ___m_rightItem.m_shared.m_movementModifier;
                        return true;
                    }
                    else
                    {
                        ___m_rightItem.m_shared.m_movementModifier = 0;
                    }
                }
                catch
                {
                }

                try
                {
                    if (___m_leftItem.m_shared.m_movementModifier > 0)
                    {
                        ___m_equipmentMovementModifier += ___m_leftItem.m_shared.m_movementModifier;
                        return true;
                    }
                    else
                    {
                        ___m_leftItem.m_shared.m_movementModifier = 0;
                    }
                }
                catch
                {
                }

                try
                {
                    if (___m_utilityItem.m_shared.m_movementModifier > 0)
                    {
                        ___m_equipmentMovementModifier += ___m_utilityItem.m_shared.m_movementModifier;
                        return true;
                    }
                    else
                    {
                        ___m_utilityItem.m_shared.m_movementModifier = 0;
                    }
                }
                catch
                {
                }

                try
                {
                    if (___m_chestItem.m_shared.m_movementModifier > 0)
                    {
                        ___m_equipmentMovementModifier += ___m_chestItem.m_shared.m_movementModifier;
                        return true;
                    }
                    else
                    {
                        ___m_chestItem.m_shared.m_movementModifier = 0;
                    }
                }
                catch
                {
                }

                try
                {
                    if (___m_legItem.m_shared.m_movementModifier > 0)
                    {
                        ___m_equipmentMovementModifier += ___m_legItem.m_shared.m_movementModifier;
                        return true;
                    }
                    else
                    {
                        ___m_legItem.m_shared.m_movementModifier = 0;
                    }
                }
                catch
                {
                }

                try
                {
                    if (___m_shoulderItem.m_shared.m_movementModifier > 0)
                    {
                        ___m_equipmentMovementModifier += ___m_shoulderItem.m_shared.m_movementModifier;
                        return true;
                    }
                    else
                    {
                        ___m_shoulderItem.m_shared.m_movementModifier = 0;
                    }
                }
                catch
                {
                }

                try
                {
                    if (___m_helmetItem.m_shared.m_movementModifier > 0)
                    {
                        ___m_equipmentMovementModifier += ___m_helmetItem.m_shared.m_movementModifier;
                        return true;
                    }
                    else
                    {
                        ___m_helmetItem.m_shared.m_movementModifier = 0;
                    }
                }
                catch
                {
                }

                return true;
                
            }
        }
    }
}
