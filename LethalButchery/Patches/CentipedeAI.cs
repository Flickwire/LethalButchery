
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace LethalButchery.Patches;

[HarmonyPatch(typeof(CentipedeAI), nameof(CentipedeAI.KillEnemy))]
internal static class Centipede_KillEnemy_Patch
{
    [HarmonyPrefix]
    private static void Prefix(CentipedeAI __instance, out Vector3[] __state)
    {
        ManualLogSource log = BepInEx.Logging.Logger.CreateLogSource("Lethal Butchery");
        log.LogInfo($"Killed a centipede at {__instance.serverPosition}, {__instance.serverRotation}");
        __state = [new Vector3(__instance.serverPosition.x, __instance.serverPosition.y, __instance.serverPosition.z), new Vector3(__instance.serverRotation.x, __instance.serverRotation.y, __instance.serverRotation.z)];
    }

    [HarmonyPostfix]
    private static void Postfix(ref CentipedeAI __instance, Vector3[] __state)
    {
        ManualLogSource log = BepInEx.Logging.Logger.CreateLogSource("Lethal Butchery");
        //Call base.KillEnemy(), destroy enemy
        EnemyAI_Patch.KillEnemy(__instance, true);
        log.LogInfo($"Destroyed centipede; time to spawn loot at {__state[0]}, {__state[1]}");
        //TODO: Spawn loot
        return;
    }
}

