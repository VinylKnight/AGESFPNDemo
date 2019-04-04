using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Click box to lock the door.")]
    [SerializeField]
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

    public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

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

    }
    public override void InteractWith()
    {
       
        if (!isOpen)
        {
            if (!isLocked)
            {
                audioSource.clip = openClip;
                animator.SetBool(shouldOpenAnimParameter, true);
                displayText = string.Empty;
                isOpen = true;

            }
            else
            {
                audioSource.clip = isLockedAudioClip;
            }
            base.InteractWith();
        }
        

    }
   
}
