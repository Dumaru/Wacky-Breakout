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
    static List<Block> pointsInvokers = new List<Block>();
    static List<UnityAction<int>> pointsListeners = new List<UnityAction<int>>();
    static List<Ball> reducedBallsInvokers = new List<Ball>();
    static List<UnityAction<int>> reducedBallsListeners = new List<UnityAction<int>>();
    static List<Ball> ballDeathInvokers = new List<Ball>();
    static List<UnityAction<int>> ballDeathListeners = new List<UnityAction<int>>();
    static List<UnityEvent> gameOverInvokers = new List<UnityEvent>();
    static List<UnityAction> gameOverListeners = new List<UnityAction>();

    static List<Block> twoArgsInvokers = new List<Block>();
    static List<UnityAction<float, float>> twoArgsListeners = new List<UnityAction<float, float>>();
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

    public static void AddPointsInvoker(Block invoker)
    {
        pointsInvokers.Add(invoker);
        foreach (UnityAction<int> listener in pointsListeners)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }
    public static void AddPointsAddedListener(UnityAction<int> listener)
    {
        pointsListeners.Add(listener);
        foreach (Block invoker in pointsInvokers)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    public static void AddReducedBallsInvoker(Ball invoker)
    {
        reducedBallsInvokers.Add(invoker);
        foreach (UnityAction<int> listener in reducedBallsListeners)
        {
            invoker.AddReducedBallsListener(listener);
        }
    }
    public static void AddReducedBallsListener(UnityAction<int> listener)
    {
        pointsListeners.Add(listener);
        foreach (Ball invoker in reducedBallsInvokers)
        {
            invoker.AddReducedBallsListener(listener);
        }
    }
    public static void AddGameOverInvoker(UnityEvent invoker)
    {
        gameOverInvokers.Add(invoker);
        foreach (UnityAction listener in gameOverListeners)
        {
            invoker.AddListener(listener);
        }
    }
    public static void AddGameOverListener(UnityAction listener)
    {
        gameOverListeners.Add(listener);
        foreach (UnityEvent invoker in gameOverInvokers)
        {
            invoker.AddListener(listener);
        }
    }
    public static void AddDeathBallInvoker(Ball invoker)
    {
        ballDeathInvokers.Add(invoker);
        foreach (UnityAction<int> listener in ballDeathListeners)
        {
            invoker.AddDeathBallEventListener(listener);
        }
    }
    public static void AddDeathdBallsListener(UnityAction<int> listener)
    {
        ballDeathListeners.Add(listener);
        foreach (Ball invoker in reducedBallsInvokers)
        {
            invoker.AddDeathBallEventListener(listener);
        }
    }
    /// <summary>
    /// Add the given script as an invoker.
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddSpeedUpInvoker(Block invoker)
    {
        invokers.Add(invoker);
        foreach (UnityAction<float, float> listener in twoArgsListeners)
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
        twoArgsListeners.Add(listener);
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