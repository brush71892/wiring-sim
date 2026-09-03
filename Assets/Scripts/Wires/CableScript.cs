using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CableScript : MonoBehaviour {
    public List<LineRenderer> linePrefabs;
    public List<Cable> cables = new List<Cable>();
    public List<Connection> connections = new List<Connection>();
    private List<LineRenderer> activeLines = new List<LineRenderer>();

    private int index;
    private int newConnection;

    void Update();

    public void AddCable(Vector2 point1, Vector2 point2, int id)
    {
        point1.Add(pointone);
        point2.Add(pointtwo);
        connection1.Add(36894); // placeholder item for connection1, can be string for the pdh/roborio
        connection2.Add(point1.Count-1);
        connection1.Add(point1.Count-2);
        connection2.Add(-1);
        wireType.Add(id);

        cables.Add(new Cable(point1, point2, id));




        LineRenderer newLine = Instantiate(linePrefabs[type], Vector3.zero, Quaternion.identity);
        newLine.positionCount = 2;
        newLine.SetPosition(0, pointone);
        newLine.SetPosition(1, pointtwo);
    }
}