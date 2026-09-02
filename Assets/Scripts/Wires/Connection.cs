using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection
{
    public Vector2 position;
    public int connectionPort;
    public int connectionType;

    public Connection(Vector2 position, int connectionPort, int connectionType)
    {
        this.position = position;
        this.connectionType = connectionType;
        this.connectionPort = connectionPort;
    }

    public int GetConnectionPort()
    {
        return connectionPort;
    }

    public void AdjustConnection(int connection)
    {
        connectionPort = connection;
    }
}