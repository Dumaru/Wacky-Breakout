using UnityEngine;

public static class EffectUtils
{
    public static bool Speeding => Camera.main.GetComponent<SpeedUpEffectMonitor>().Speeding;
    public static float TimeLeft => Camera.main.GetComponent<SpeedUpEffectMonitor>().TimeLeft;
    public static float SpeedUpFactor => Camera.main.GetComponent<SpeedUpEffectMonitor>().SpeedUpFactor;
}