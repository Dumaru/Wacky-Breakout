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

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

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
    }
    #endregion
}
