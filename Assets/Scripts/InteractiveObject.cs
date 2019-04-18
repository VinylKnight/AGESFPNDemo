﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [Tooltip("Text that will display in the UI when the player looks at this object in the world")]
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);
    
    public virtual string DisplayText => displayText;
    protected AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();
        }
        catch (System.Exception)
        {
            throw new System.Exception("Interactive Object requires an AudioSource Component with an Audio Clip.");
        } 
        Debug.Log($"Player interacted with: {gameObject.name}.");
    }
}
