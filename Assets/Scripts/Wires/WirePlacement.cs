using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

// MAKES WIRES GO BACK TO START IF THEY ARE TOO SHORT, FIX THIS

public class WirePlacement : MonoBehaviour
{
    public WireScript wireScript;
    private bool isPlacing = false;
    private bool movingWire = false;
    private bool isSelecting = false;
    private int clickRadius = 5;

    void Update()
    {
        if (Keyboard.current != null && isPlacing == false)
        {
            if (Keyboard.current.vKey.wasPressedThisFrame)
            {
                // add code detecting if branching off of another wire
                Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 10f));
                isSelecting = true;

                // wireScript.AddWire(new Vector2(worldPos.x, worldPos.y), new Vector2(worldPos.x, worldPos.y), 0);
            }
            if (isSelecting == true)
            {
                if (Keyboard.current.digit1Key.wasPressedThisFrame)
                {
                    Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 10f));
                    wireScript.AddWire(new Vector2(worldPos.x, worldPos.y), new Vector2(worldPos.x, worldPos.y), 0);
                    isSelecting = false;
                    isPlacing = true;
                }
                if (Keyboard.current.digit2Key.wasPressedThisFrame)
                {
                    Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 10f));
                    wireScript.AddWire(new Vector2(worldPos.x, worldPos.y), new Vector2(worldPos.x, worldPos.y), 1);
                    isSelecting = false;
                    isPlacing = true;
                }
                if (Keyboard.current.digit3Key.wasPressedThisFrame)
                {
                    Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 10f));
                    wireScript.AddWire(new Vector2(worldPos.x, worldPos.y), new Vector2(worldPos.x, worldPos.y), 2);
                    isSelecting = false;
                    isPlacing = true;
                }
                if (Keyboard.current.digit4Key.wasPressedThisFrame)
                {
                    Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 10f));
                    wireScript.AddWire(new Vector2(worldPos.x, worldPos.y), new Vector2(worldPos.x, worldPos.y), 3);
                    isSelecting = false;
                    isPlacing = true;
                }
            }
        }
        if (isPlacing == true)
        {
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, 10f));
            wireScript.AdjustWire(new Vector2(worldPosition.x, worldPosition.y));
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                for (int i=0; i<wireScript.GetLength()-1; i++)
                {
                    if (wireScript.GetPoint1(i).x-0.5<worldPosition.x && wireScript.GetPoint1(i).x+0.5>worldPosition.x && wireScript.GetPoint1(i).y-0.5<worldPosition.y && wireScript.GetPoint1(i).y+0.5>worldPosition.y)
                    {
                        wireScript.AdjustWire(wireScript.GetPoint1(i));
                    }
                    else if (wireScript.GetPoint2(i).x-0.5<worldPosition.x && wireScript.GetPoint2(i).x+0.5>worldPosition.x && wireScript.GetPoint2(i).y-0.5<worldPosition.y && wireScript.GetPoint2(i).y+0.5>worldPosition.y)
                    {
                        wireScript.AdjustWire(wireScript.GetPoint2(i));
                    }
                }
                isPlacing = false;
            }
        }
        if (isPlacing == false)
        {
            // attaching a wire
        }
    }
}
