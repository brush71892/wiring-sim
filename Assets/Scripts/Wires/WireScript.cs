using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.InputSystem;

public class WireScript : MonoBehaviour
{
    [SerializeField] private LineRenderer linePrefab;
    public List<Vector2> point1 = new List<Vector2>();
    public List<Vector2> point2 = new List<Vector2>();
    public List<int> connection1 = new List<int>();
    public List<int> connection2 = new List<int>();

    private List<LineRenderer> activeLines = new List<LineRenderer>();
    private int index;

    void Update()
    {
        if (Keyboard.current != null)
        {
            if (Keyboard.current.fKey.isPressed) Debug.Log(string.Join(", ", connection1));  
            if (Keyboard.current.vKey.isPressed) Debug.Log(string.Join(", ", connection2));  
        }
    }
    
    public void AddWire(Vector2 pointone, Vector2 pointtwo)
    {
        point1.Add(pointone);
        point2.Add(pointtwo);
        connection1.Add(-1);
        connection2.Add(point1.Count-1);
        connection1.Add(point1.Count-2);
        connection2.Add(-1);

        LineRenderer newLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        newLine.positionCount = 2;
        newLine.SetPosition(0, pointone);
        newLine.SetPosition(1, pointtwo);

        activeLines.Add(newLine);
    }

    public void AdjustWire(Vector2 newPos)
    {
        index = point1.Count - 1;
        point2[index] = newPos;
        
        if (index >= 0 && index < activeLines.Count)
        {
            activeLines[index].SetPosition(1, newPos);
        }
    }

    public int GetLength()
    {
        return point1.Count;
    }

    public Vector2 GetPoint1(int index)
    {
        return point1[index];
    }

    public Vector2 GetPoint2(int index)
    {
        return point2[index];
    }
}