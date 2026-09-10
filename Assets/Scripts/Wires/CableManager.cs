using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CableManager : MonoBehaviour {
    public List<LineRenderer> linePrefabs;
    public List<Cable> cables = new List<Cable>();
    public List<Connection> connections = new List<Connection>();
    private List<LineRenderer> activeLines = new List<LineRenderer>();

    private int index;
    private int newConnection;

    void Update();

    public void AddCable(Vector2 point1, Vector2 point2, int id)
    {
        cables.Add(new Cable(point1, point2, id));

        LineRenderer newLine = Instantiate(linePrefabs[type], Vector3.zero, Quaternion.identity);
        newLine.positionCount = 2;
        newLine.SetPosition(0, pointone);
        newLine.SetPosition(1, pointtwo);
    }

    public void AdjustWire(int wireid, int portid, Vector2 newPos)
    {
        if (portid == 0){cables[wireid].UpdateFirstPosition(newPos);}
        else if (portid == 1){cables[wireid].UpdateSecondPosition(newPos);}
    }

    public void AdjustConnection1(Cable fih, sam dih)
    {
        connections.fhi;
    }
}