using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script will be used to cause action when interacting with object and player presses interact button.
/// The script will then call object's IInteractive's InteractWith method.
/// </summary>
public class InteractWithLookedAt : MonoBehaviour
{
    [SerializeField]
    private DetectLookedAtInteractive detectLookedAtInteractive;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && detectLookedAtInteractive != null)
        {
            Debug.Log("Player pressed the interact button.");
            detectLookedAtInteractive.LookedAtInteractive.InteractWith();
        }
    }
}
