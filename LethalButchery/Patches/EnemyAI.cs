
using BepInEx.Logging;
using HarmonyLib;

namespace LethalButchery.Patches;

[HarmonyPatch(typeof(EnemyAI), nameof(EnemyAI.KillEnemy))]
internal static class KillEnemy_Patch
{
    [HarmonyPostfix]
    private static void Postfix(EnemyAI __instance, bool __0)
    {
        ManualLogSource log = Logger.CreateLogSource(nameof(KillEnemy_Patch));
        log.LogInfo($"Custom kill enemy called on {__instance.enemyType}; destroy: {__0}");
        return;
    }
}

[HarmonyPatch(typeof(EnemyAI), nameof(EnemyAI.Start))]
internal static class Start_Patch
{
    [HarmonyPostfix]
    private static void Postfix(EnemyAI __instance)
    {
        ManualLogSource log = Logger.CreateLogSource(nameof(Start_Patch));
        log.LogInfo($"Custom start called on {__instance.enemyType};");
        return;
    }
}
