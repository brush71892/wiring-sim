using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hardware
{
    public List<Vector2> position;
    public int hardwareID, hardwareID2, cur, connNum;
    public List<Lih> connections;
    public List<boolean> ends;
    public List<int> crimpedPorts;

    public String HardwareType;
    public String name;
    public boolean rotated = false;

    public List<String> portTypes;

    // public Sprite base;
    public boolean canMove, attached;
    public float difX, difY, cabledx, cabledy;

    public Fih(Vector2 pos, String hardwareType) {
        this.position = pos;
        this.HardwareType = hardwareType;

        if (hardwareType != "placeholder")
        {
            connections = new List<Lih>();
            ends = new List<boolean>();
        }
    }

    public Lih getCableConnections()
    {
        
    }
}
