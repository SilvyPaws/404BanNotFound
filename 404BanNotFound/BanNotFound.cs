using SkyFrost.Base;
using HarmonyLib;
using ResoniteModLoader;

namespace BanNotFound;
public class _404BanNotFound : ResoniteMod
{
    internal const string VERSION_CONSTANT = "1.0.0";
    public override string Name => "404BanNotFound";
    public override string Author => "SilvyPaws";
    public override string Version => VERSION_CONSTANT;
    public override string Link => "https://github.com/SilvyPaws/404BanNotFound/";

    public override void OnEngineInit()
    {
        Harmony harmony = new Harmony("io.github.silvypaws.404BanNotFound");
        harmony.PatchAll();
    }

    //Patch 1
    [HarmonyPatch(typeof(User))]
    [HarmonyPatch(nameof(User.IsPublicBanned), MethodType.Getter)]
    class Is_Public_Banned_Patch
    {
        static bool Prefix(ref bool __result)
        {
            __result = false;
            return false; // I'm just skipping the original method
        }
    }

    //Patch 2
    [HarmonyPatch(typeof(User))]
    [HarmonyPatch(nameof(User.PublicBanType), MethodType.Getter)]
    class Is_Public_Banned_Type
    {
        static bool Prefix(ref PublicBanType? __result)
        {
            __result = null;
            return false; // I'm just skipping the original method
        }
    }
}