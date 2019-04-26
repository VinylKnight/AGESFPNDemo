using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
    private InventoryObject associatedInventoryObject;

    [Tooltip("The image component used to show the associaed object's icon.")]
    [SerializeField]
    private Image iconImage;

    private void Start()
    {
        iconImage.sprite = associatedInventoryObject.Icon;

    }
}
