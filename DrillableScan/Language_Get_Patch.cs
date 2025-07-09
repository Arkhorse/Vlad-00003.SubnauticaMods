using HarmonyLib;
using System;

namespace DrillableScan
{
	[HarmonyPatch(typeof(Language), nameof(Language.Get), new Type[] { typeof(string) })]
	class Language_Get_Patch
	{
		static bool Prefix(Language __instance, ref string __result, string key)
		{
			if (__instance == null) return true;
			try
			{
				if (key.IndexOf("drillable", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					if (__instance.TryGet(key, out __result))
					{
						__result += " (Drillable)";
						return false;
					}
				}
			}
			catch { }
			return true;
		}
	}
}
