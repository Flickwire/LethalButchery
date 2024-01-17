
using HarmonyLib;
using System;
using System.Runtime.CompilerServices;

namespace LethalButchery.Patches;

[HarmonyPatch]
internal class EnemyAI_Patch
{
    [HarmonyReversePatch]
    [HarmonyPatch(typeof(EnemyAI), nameof(EnemyAI.KillEnemy))]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void KillEnemy(object instance, bool destroy = false)
    {
        throw new NotImplementedException("Stub");
    }
}
