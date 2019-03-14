using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This Script displays info about the interactive object currently being looked at.
/// The text should be hidden if the player is not currently looking at an interactable object/element.
/// </summary>
public class LookedAtInteractiveDisplayText : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    private Text displayText;

    private void UpdateDislpayText()
    {
        displayText.text = lookedAtInteractive.DisplayText;
    }
}
