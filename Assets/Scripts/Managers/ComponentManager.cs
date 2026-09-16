using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class ComponentManager : MonoBehaviour
{
    [Header("Component Slots")] //Creates a header in the inspector for the component slots
    [SerializeField] private ComponentSlot[] slots = new ComponentSlot[10];
    // component slot identifications: 1-battery, 2-breaker, 3- not added
    
    public WireScript wireScript; //Reference to the WireScript component, which is used to manage wire connections
    public List<string> componentSlots; //List of component slot names, which is used to identify the components that can be placed
    private GameObject previewObject; //Reference to the preview object, which is used to show where the component will be placed

    private bool placementMenuOpen = false; //Tracks whether the placement menu is open
    private bool placing = false; //Tracks whether a component is currently being placed

    private int placementNumber; //Tracks the index of the component slot that is currently being placed

    public float placementViewOpacity = 0.5f; //The opacity of the placement preview object, which is used to make it semi-transparent


    void Update()
    {
        OpenPlacementMenu();//Checks if cKey is pressed and if it is it opens the placement menu

        if (placementMenuOpen)
            CheckSlotSelection();

        if (placing)
        {
            FollowMouse();

            if (Mouse.current.leftButton.wasPressedThisFrame)//Checks if the left mouse button is pressed and if it is it places the component
                Place();
                PortConfigs(placementNumber);

            if (Keyboard.current.escapeKey.wasPressedThisFrame)//Checks if the escape key is pressed and if it is it cancels the placement
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

    void CheckSlotSelection() //Will be changed into a drag and drop system later, but for now it will be a number key selection
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

    void FollowMouse()//Makes the preview object follow the mouse position, so that the player can see where the component will be placed
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouse.z = 0;//Sets z to 0 so that the preview object is placed on the same plane as the other objects in the scene

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

    void CancelPlacement()//Stops the placement of the component and destroys the preview object
    {
        Destroy(previewObject);//Destroys preview

        previewObject = null; //Resets which one is being previewed secretly

        placing = false; //Stops the placing completely
        placementMenuOpen = false; //Closes placementMenu
    }
}