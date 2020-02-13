using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields
    private static ConfigurationData configurationData;
        
    #endregion
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond => configurationData.PaddleMoveUnitsPerSecond;

    public static float BallImpulseForce => configurationData.BallImpulseForce;

    public static float BallLifeTime => configurationData.BallLifeTime;
    public static float MinSpawnTime => configurationData.MinSpawnTime;
    public static float MaxSpawnTime  => configurationData.MaxSpawnTime;
    public static int StandarBlockPoints  => configurationData.StandarBlockPoints;
    public static int BonusBlockPoints  => configurationData.BonusBlockPoints;
    public static int PickupBlockPoints  => configurationData.PickupBlockPoints;

    public static float StandardBlockProbability => configurationData.StandardBlockProbability;
    public static float BonusBlockProbability => configurationData.BonusBlockProbability;
    public static float SpeedUpBlockProbability => configurationData.SpeedUpBlockProbability;
    public static float FreezerBlockProbability => configurationData.FreezerBlockProbability;
    public static int BallsPerGame => configurationData.BallsPerGame;
    public static float FreezerEffectDuration => configurationData.FreezerEffectDuration;
    public static float SpeedUpEffectDuration => configurationData.SpeedUpEffectDuration;
    public static float SpeedUpEffectFactor => configurationData.SpeedUpEffectFactor;

    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
