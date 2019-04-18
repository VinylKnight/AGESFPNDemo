﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Assigning a key here will lock the door. If the player has the key in their inventory, they can open teh locked door.")]
    [SerializeField]
    private InventoryObject key;
    
    //[Tooltip("Click box to lock the door.")]
    //[SerializeField]
    private bool isLocked;

    [Tooltip("Click box to lock the door.")]
    [SerializeField]
    private string lockedDisplayText = "Locked";

    [Tooltip("Audio clip played when the door is locked.")]
    [SerializeField]
    private AudioClip isLockedAudioClip;

    [Tooltip("Audio clip played when the door is unlocked.")]
    [SerializeField]
    private AudioClip openClip;

    //public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

    public override string DisplayText
    {
        get
        {
            string toReturn;
            if (isLocked)
                toReturn = hasKey ? $"Use {key.ObjectName}" : lockedDisplayText;
            
            else
                toReturn = base.DisplayText;

            return toReturn;
        }

    }

    private bool hasKey => PlayerInventory.InventoryObjects.Contains(key);
    private Animator animator;
    private bool isOpen = false;
    private int shouldOpenAnimParameter = Animator.StringToHash(nameof(shouldOpenAnimParameter));

    /// <summary>
    /// Using a constructor to displayText in the editor
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }
    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (key != null)
        {
            isLocked = true;
        }
    }

    public override void InteractWith()
    {
       
        if (!isOpen)
        {
            if (isLocked && !hasKey)
            {
                audioSource.clip = isLockedAudioClip;
            }
            else
            {
                audioSource.clip = openClip;
                animator.SetBool(shouldOpenAnimParameter, true);
                displayText = string.Empty;
                isOpen = true;
            }
            //if (!isLocked)
            //{
            //    audioSource.clip = openClip;
            //    animator.SetBool(shouldOpenAnimParameter, true);
            //    displayText = string.Empty;
            //    isOpen = true;
            //}
            //else
            //{
            //    audioSource.clip = isLockedAudioClip;
            //}
            base.InteractWith();
        }  
    }
}
