using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.InputSystem;

public class WireScript : MonoBehaviour
{

    public List<LineRenderer> linePrefabs;
    public List<Vector2> point1 = new List<Vector2>();
    public List<Vector2> point2 = new List<Vector2>();
    public List<int> connection1 = new List<int>();
    public List<int> connection2 = new List<int>();
    public List<int> wireType = new List<int>();

    private List<LineRenderer> activeLines = new List<LineRenderer>();
    private int index;
    private int newConnection;

    void Update() {}
    
    public void AddWire(Vector2 pointone, Vector2 pointtwo, int type)
    {
        point1.Add(pointone);
        point2.Add(pointtwo);
        connection1.Add(-1);
        connection2.Add(point1.Count-1);
        connection1.Add(point1.Count-2);
        connection2.Add(-1);
        wireType.Add(type);

        LineRenderer newLine = Instantiate(linePrefabs[type], Vector3.zero, Quaternion.identity);
        newLine.positionCount = 2;
        newLine.SetPosition(0, pointone);
        newLine.SetPosition(1, pointtwo);

        activeLines.Add(newLine);
    }

    public void AddPortWConnect1(Vector2 pointone, Vector2 pointtwo, int id) {
        point1.Add(pointone);
        point2.Add(pointtwo);
        connection1.Add(36894); // placeholder item for connection1, can be string for the pdh/roborio
        connection2.Add(point1.Count-1);
        connection1.Add(point1.Count-2);
        connection2.Add(-1);
        wireType.Add(id);

        LineRenderer newLine = Instantiate(linePrefabs[type], Vector3.zero, Quaternion.identity);
        newLine.positionCount = 2;
        newLine.SetPosition(0, pointone);
        newLine.SetPosition(1, pointtwo);
    }

    public void AddPortWConnect2(Vector2 pointone, Vector2 pointtwo, int id) {
        point1.Add(pointone);
        point2.Add(pointtwo);
        connection1.Add(-1);
        connection2.Add(36894); // again, a placeholder
        connection1.Add(point1.Count-2);
        connection2.Add(-1);
        wireType.Add(id);

        LineRenderer newLine = Instantiate(linePrefabs[type], Vector3.zero, Quaternion.identity);
        newLine.positionCount = 2;
        newLine.SetPosition(0, pointone);
        newLine.SetPosition(1, pointtwo);
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

    public void AdjustConnection(int index, bool thing)
    {
        newConnection = 2*(point1.Count-1);
        if (thing) connection2[index]=newConnection; else connection1[index]=newConnection;
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

    public int GetConnection1(int index)
    {
        return connection1[index];
    }

    public int GetConnection2(int index)
    {
        return connection2[index];
    }
}