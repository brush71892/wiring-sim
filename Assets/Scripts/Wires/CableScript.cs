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

    void Update(){}

    public void AddCable(Vector2 point1, Vector2 point2, int id)
    {
        cables.Add(new Cable(point1, point2, id));

        LineRenderer newLine = Instantiate(linePrefabs[id], Vector3.zero, Quaternion.identity);
        newLine.positionCount = 2;
        newLine.SetPosition(0, point1);
        newLine.SetPosition(1, point2);
    }
}