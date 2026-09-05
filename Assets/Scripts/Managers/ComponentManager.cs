using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class ComponentManager : MonoBehaviour
{
    [Header("Component Slots")]
    [SerializeField] private ComponentSlot[] slots = new ComponentSlot[10];
    // component slot identifications: 1-battery, 2-breaker, 3- not added
    
    public WireScript wireScript;
    public List<string> componentSlots;

    private GameObject previewObject;

    private bool placementMenuOpen = false;
    private bool placing = false;
    
    private int placementNumber;

    public float placementViewOpacity = 0.5f;


    void Update()
    {
        OpenPlacementMenu();

        if (placementMenuOpen)
            CheckSlotSelection();

        if (placing)
        {
            FollowMouse();

            if (Mouse.current.leftButton.wasPressedThisFrame)
                Place();
                PortConfigs(placementNumber);

            if (Keyboard.current.escapeKey.wasPressedThisFrame)
                CancelPlacement();
        }
    }

    void OpenPlacementMenu()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            placementMenuOpen = true;
            Debug.Log("Placement Mode");
        }
    }

    void CheckSlotSelection()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame) BeginPlacement(0);
        if (Keyboard.current.digit2Key.wasPressedThisFrame) BeginPlacement(1);
        if (Keyboard.current.digit3Key.wasPressedThisFrame) BeginPlacement(2);
        if (Keyboard.current.digit4Key.wasPressedThisFrame) BeginPlacement(3);
        if (Keyboard.current.digit5Key.wasPressedThisFrame) BeginPlacement(4);
        if (Keyboard.current.digit6Key.wasPressedThisFrame) BeginPlacement(5);
        if (Keyboard.current.digit7Key.wasPressedThisFrame) BeginPlacement(6);
        if (Keyboard.current.digit8Key.wasPressedThisFrame) BeginPlacement(7);
        if (Keyboard.current.digit9Key.wasPressedThisFrame) BeginPlacement(8);
        if (Keyboard.current.digit0Key.wasPressedThisFrame) BeginPlacement(9);
    }

    void BeginPlacement(int slot)
    {
        if (slots[slot].prefab == null)
            return;

        if (previewObject != null)
            Destroy(previewObject);

        previewObject = Instantiate(slots[slot].prefab);

        placementMenuOpen = false;
        placing = true;
        placementNumber = slot;
    }

    void FollowMouse()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouse.z = 0;

        previewObject.transform.position = mouse;
    }

    void Place()
    {
        SpriteRenderer sprite = previewObject.GetComponentInChildren<SpriteRenderer>();

        Color color = sprite.color;
        color.a = 1f; 
        sprite.color = color;

        previewObject = null;
        placing = false;
    }

    void PortConfigs(int slot) {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouse.z = 0;

        if (slot == 0) wireScript.AddPortWConnect1(new Vector2(mouse.x + 5, mouse.y + 5), new Vector2(mouse.x + 7, mouse.y + 7), 1);
            // fill rest of cases here, portwconnect1 and 2 should attach to assigned objects, limiting wire placement 
    }

    void CancelPlacement()
    {
        Destroy(previewObject);

        previewObject = null;

        placing = false;
        placementMenuOpen = false;
    }
}