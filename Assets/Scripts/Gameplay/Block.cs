﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Block : MonoBehaviour
{
    protected int pointsWorthed;

    AddPointsEvent addPointsEvent;
    BlockDestroyed lastBlockDestroyed;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        lastBlockDestroyed = new BlockDestroyed();
        addPointsEvent = new AddPointsEvent();
        EventManager.AddPointsInvoker(this);
        EventManager.AddGameOverInvoker(lastBlockDestroyed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            this.addPointsEvent.Invoke(this.pointsWorthed);
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
            if (blocks.Length == 1)
            {
                lastBlockDestroyed.Invoke();
            }
            AudioManager.Play(AudioClipName.BRICK_HIT);
            Destroy(this.gameObject);

        }
    }
    public void AddPointsAddedListener(UnityAction<int> listener)
    {
        this.addPointsEvent.AddListener(listener);
    }
}
