using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    //TODO: Add long description field
    //TODO: Add Icon Field

    /// <summary>
    /// When the player interacts with an inventory object, we need to do things:
    /// 1. Add the inventory object to the PlayerInventory list
    /// 2. Remove the object from the game world / scene
    /// </summary>
  
    [Tooltip("Name of the object, as it will appear in the inventory menu UI.")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    public string ObjectName => objectName;
    private new Renderer renderer;
    private new Collider collider;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }
    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }
    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        collider.enabled = false;
        renderer.enabled = false;
    }
}
