using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection
{
    public Vector2 position;
    public int connNum;
    public int connectionType;

    public Connection(Vector2 pos, int connectionType, int connNum)
    {
        position = pos;
        this.connectionType = connectionType;
        this.connNum = connNum;
    }
}