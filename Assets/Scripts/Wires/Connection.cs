using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Each cable has two connections to other cables. The connection's 'connection' attribute is a cable, 
// each cable is created in the cablescript.
// hardware is created in the componentManager script and can also be accessed in the hardware script.
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

    public Connection(Vector2 position, Cable connection, Cable origin)
    {
        
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