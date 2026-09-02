using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable
{
    public float voltage;
    public List<Vector2> coordinates;
    public Connection connection1, connection2;
    public int connection1port, connection2port;
    
    private List<int> portReturn;

    public Cable(Vector2 point1, Vector2 point2, int type)
    {
        voltage = 0;
        coordinates = new List<Vector2>();
        this.connection1 = new Connection(point1, -1, type);
        this.connection2 = new Connection(point2, -1, type);
        connection1port = connection1.GetConnectionPort();
        connection2port = connection2.GetConnectionPort();
    }

    public void UpdateFirstPosition(Vector2 newPosition){coordinates[0] = newPosition;}
    public void UpdateSecondPosition(Vector2 newPosition){coordinate[0] = newPosition;}
    public void AdjustPosition(Vector2 move){coordinates[0] = coordinates[0]+move; coordinates[1] = coordinates[1]+move;}

    public void UpdatePorts(int port1, int port2)
    {
        connection1.AdjustConnection(port1);
        connection2.AdjustConnection(port2);
    }

    public List<int> GetConnections()
    {
        portReturn.RemoveAll;
        portReturn.Add(connection1port);
        portReturn.Add(connection2port);
    }

}