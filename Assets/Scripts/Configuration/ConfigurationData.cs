using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    static float ballLifeTime = 10;
    static float minSpawnTime = 5;
    static float maxSpawnTime = 10;
    static int standarBlockPoints = 1; 
    static int bonusBlockPoints = 10; 
    static int pickupBlockPoints = 15; 

    static float standardBlockProbability = 40;
    static float bonusBlockProbability = 30;
    static float speedUpBlockProbability = 20;
    static float freezerBlockProbability = 10;
    static int ballsPerGame = 30;
    static float freezerEffectDuration = 2;
    static float speedUpEffectDuration = 2;
    static float speedUpEffectFactor = 1.5f;


    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond => paddleMoveUnitsPerSecond;
    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce =>  ballImpulseForce;
    public float BallLifeTime => ballLifeTime;
    public float MinSpawnTime => minSpawnTime;
    public float MaxSpawnTime => maxSpawnTime;
    public int StandarBlockPoints => standarBlockPoints;
    public int BonusBlockPoints => bonusBlockPoints;
    public int PickupBlockPoints => pickupBlockPoints;
    public float StandardBlockProbability => standardBlockProbability;
    public float BonusBlockProbability => bonusBlockProbability;
    public float SpeedUpBlockProbability => speedUpBlockProbability;
    public float FreezerBlockProbability => freezerBlockProbability;
    public int BallsPerGame => ballsPerGame;
    public float FreezerEffectDuration => freezerEffectDuration;
    public float SpeedUpEffectDuration => speedUpEffectDuration;
    public float SpeedUpEffectFactor => speedUpEffectFactor;

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader reader = null;
        try
        {
            reader = new StreamReader(
                Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName)
            );

            string[] headerList = reader.ReadLine().Split(',');
            string[] valuesList = reader.ReadLine().Split(',');
            
            SetConfigurationData(valuesList);
        }
        catch (System.Exception)
        {
            throw;
        }        
    }
    #endregion

    #region Methods
    /// <summary>
    /// Sets the values of the configuration data file into the fields
    /// </summary>
    /// <param name="values"></param>
    private void SetConfigurationData(String[] values){
        paddleMoveUnitsPerSecond = float.Parse(values[0]); 
        ballImpulseForce =  float.Parse(values[1]);
        ballLifeTime = float.Parse(values[2]);
        minSpawnTime = float.Parse(values[3]);
        maxSpawnTime = float.Parse(values[4]);
        standarBlockPoints = int.Parse(values[5]);
        bonusBlockPoints = int.Parse(values[6]);
        pickupBlockPoints = int.Parse(values[7]);
        standardBlockProbability = float.Parse(values[8]);
        bonusBlockProbability = float.Parse(values[9]);
        freezerBlockProbability = float.Parse(values[10]);
        speedUpBlockProbability = float.Parse(values[11]);
        ballsPerGame = int.Parse(values[12]);
        freezerEffectDuration = float.Parse(values[13]);
        speedUpEffectDuration = float.Parse(values[14]);
        speedUpEffectFactor = float.Parse(values[15]);
    }
    #endregion
}
