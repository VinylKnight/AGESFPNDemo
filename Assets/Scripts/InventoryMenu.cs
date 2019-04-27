﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuTogglePrefab;
    [Tooltip("The content of the scrollview fro the list of inventory items.")]
    [SerializeField]
    private Transform inventoryListContentArea;

    private CanvasGroup canvasGroup;
    private static InventoryMenu instance;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    private AudioSource audioSource;
    private ToggleGroup toggleGroup;

    private bool IsVisible => canvasGroup.alpha > 0;
    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is currently no InventoryMenu instance, " +
                    "but you are trying to access it! Make sure the InventoryMenu script is applied to a GameObject in your scene!");
            return instance;
        }
        private set { instance = value; }
    }

    public void ExitMenuButtonClicked()
    {
        HideMenu();
    }
    /// <summary>
    /// Instantiates a new InventoryMenuItemToggle prefab and adds it to the menu.
    /// </summary>
    /// <param name="inventoryObjectToAdd"></param>
    public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
    {
        GameObject clone = Instantiate(inventoryMenuTogglePrefab, inventoryListContentArea);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;
    }
    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        rigidbodyFirstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        audioSource.Play();
    }
    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rigidbodyFirstPersonController.enabled = true;
        audioSource.Play();
    }
    private void Start()
    {
        audioSource.volume = 0;
        HideMenu();
        StartCoroutine(WaitForAudioClip());
        Debug.Log("We're not done waiting.");
    }
    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Show Inventory Menu"))
        {
            if (IsVisible)
                HideMenu();
            else
                ShowMenu();
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("There is already an instance of InventoryMenu and there can only be one.");

        canvasGroup = GetComponent<CanvasGroup>();
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        audioSource = GetComponent<AudioSource>();
        //toggleGroup = GetComponentInChildren<ToggleGroup>();
    }
    private IEnumerator WaitForAudioClip()
    {
        float originalVolume = audioSource.volume;
        audioSource.volume = 0;
        Debug.Log("Start Waiting");
        yield return new WaitForSeconds(audioSource.clip.length);
        Debug.Log("Done Waiting");
        audioSource.volume = originalVolume;
    }
}
