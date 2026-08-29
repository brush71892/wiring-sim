using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

// MAKES WIRES CONNECT TO THEMSELVES IF THEY ARE TOO SHORT<<

public class WirePlacement : MonoBehaviour
{
    // bring in the wireScript
    public WireScript wireScript;

    // detects if the user is placing a wire
    private bool isPlacing = false;

    // detects if the user is moving a wire
    private bool movingWire = false;

    // detects if the user is selecting a wire
    private bool isSelecting = false;

    // determines how far the minimum distance is for the wire to auto-connect to another.
    public double clickRadius = 0.4;

    private bool hit = false;
    void Update()
    {
        if (Keyboard.current != null && isPlacing == false)
        {
            if (Keyboard.current.vKey.wasPressedThisFrame)
            {
                // add code detecting if branching off of another wire

                // find mouse position
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
                hit=false;
                for (int i=0; i<wireScript.GetLength()-1; i++)
                {
                    if (!hit)
                    {
                        
                    }
                    if (wireScript.GetPoint2(i).x-clickRadius<worldPosition.x && wireScript.GetPoint2(i).x+clickRadius>worldPosition.x && wireScript.GetPoint2(i).y-clickRadius<worldPosition.y && wireScript.GetPoint2(i).y+clickRadius>worldPosition.y)
                    {
                        Debug.Log("2");
                        /*
                        if (wireScript.GetConnection1(1+(i*2))==-1) 
                        {
                            Debug.Log("connect1 open on p2");
                            wireScript.AdjustConnection(i, false);
                            wireScript.AdjustWire(wireScript.GetPoint2(i));
                        }
                        else if (wireScript.GetConnection2(1+(i*2))==-1)
                        {
                            Debug.Log("connect2 open on p2");
                            wireScript.AdjustConnection(i, true);
                            wireScript.AdjustWire(wireScript.GetPoint2(i));
                        }
                        else
                        {
                            Debug.Log("failed to find an open connection");
                        }
                        */
                        hit=true;
                    }
                    else if (wireScript.GetPoint1(i).x-clickRadius<worldPosition.x && wireScript.GetPoint1(i).x+clickRadius>worldPosition.x && wireScript.GetPoint1(i).y-clickRadius<worldPosition.y && wireScript.GetPoint1(i).y+clickRadius>worldPosition.y)
                    {
                        Debug.Log("1");
                        /*
                        if (wireScript.GetConnection1(i*2)==-1) 
                        {
                            Debug.Log("connect1 open on p1");
                            wireScript.AdjustConnection(i, false);
                            wireScript.AdjustWire(wireScript.GetPoint1(i));
                        }
                        else if (wireScript.GetConnection2(i*2)==-1)
                        {
                            Debug.Log("connect2 open on p1");
                            wireScript.AdjustConnection(i, true);
                            wireScript.AdjustWire(wireScript.GetPoint1(i));
                        }
                        else
                        {
                            Debug.Log("failed to find an open connection");
                        }
                        */
                        hit=true;
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
