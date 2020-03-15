using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages conections between event invokers and listeners
/// </summary>
public static class EventManager
{

    #region Fields
    static List<Block> invokers = new List<Block>();
    static List<UnityAction<float>> listeners = new List<UnityAction<float>>();
    static List<UnityAction<float, float>> speedUpListeners = new List<UnityAction<float, float>>();
    #endregion

    #region Public Methods
    /// <summary>
    /// Adds the given script as an invoker
    /// </summary>
    /// <param name="invoker">The invoker</param>
    public static void AddInvoker(Block invoker)
    {
        invokers.Add(invoker);
        // foreach (UnityAction<float> listener in listeners)
        // {
        //     //  TODO: Add listeners to all kind of invokers

        // }
    }

    /// <summary>
    /// Add the given script as an invoker.
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddSpeedUpInvoker(Block invoker)
    {
        invokers.Add(invoker);
        foreach (UnityAction<float, float> listener in speedUpListeners)
        {
            PickupBlock pickupBlock = (invoker as PickupBlock);
            if (pickupBlock != null) pickupBlock.AddSpeedUpEffectListener(listener);
        }
    }


    /// <summary>
    /// Adds the given event handler as a listener
    /// </summary>
    /// <param name="listener">The event handler</param>
    public static void AddFreezerEffectListener(UnityAction<float> listener)
    {
        listeners.Add(listener);
        foreach (Block block in invokers)
        {
            PickupBlock pickupBlock = (block as PickupBlock);
            if (pickupBlock != null && pickupBlock.EffectKind.Equals(PickupEffect.Freezer))
            {
                pickupBlock.AddFreezerEffectListener(listener);
            }
        }
    }

    /// <summary>
    /// Adds the given event handler as a listener
    /// </summary>
    /// <param name="listener"></param>
    public static void AddSpeedUpEffectListener(UnityAction<float, float> listener)
    {
        speedUpListeners.Add(listener);
        foreach (Block block in invokers)
        {
            PickupBlock pickupBlock = (block as PickupBlock);
            if (pickupBlock != null && pickupBlock.EffectKind.Equals(PickupEffect.Speedup))
            {
                pickupBlock.AddSpeedUpEffectListener(listener);
            }
        }
    }
    #endregion

}