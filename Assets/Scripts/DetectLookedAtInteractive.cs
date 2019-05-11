using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// Detects interactive elements the player is looking at.
/// </summary>
public class DetectLookedAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of Raycast used to detect interactive objects.")]
    [SerializeField]
    private Transform raycastOrigin;
    [Tooltip("Determines the length from the raycast origin we will search for Interactive objects.")]
    [SerializeField]
    private float maxRange = 5.0f;

    /// <summary>
    /// Event raised when the player looks at a different IInteractive.
    /// </summary>

    public static event Action<IInteractive> LookedAtInteractiveChanged;
   
    private IInteractive lookedAtInteractive;

    public IInteractive LookedAtInteractive
    {
        get { return lookedAtInteractive; }
        private set
        {
            bool isInteractiveChanged = value != lookedAtInteractive;
            if (isInteractiveChanged)
            {
                lookedAtInteractive = value;
                LookedAtInteractiveChanged?.Invoke(LookedAtInteractive);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       LookedAtInteractive = GetLookedAtInteractive();
    }

    private IInteractive GetLookedAtInteractive()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);
        bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);
        IInteractive interactive = null;
        LookedAtInteractive = interactive;
        if (objectWasDetected == true)
        {
            Debug.Log("Player is looking at: " + hitInfo.collider.gameObject.name);
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }
        return interactive;
    }
}
