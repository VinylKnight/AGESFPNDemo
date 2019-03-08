using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, maxRange);
    }
}
