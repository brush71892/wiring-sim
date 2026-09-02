using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fih
{
    public List<Vector2> Position;
    public int hardwareID, hardwareID2, cur, connNum;
    public List<Lih> connections;
    public List<boolean> ends;
    public List<int> crimpedPorts;

    public int HardwareType;
    public String name;
    public boolean rotated = false;
}
