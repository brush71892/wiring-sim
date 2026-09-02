using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable
{
    public float voltage;
    public List<Vector2> coordinates;
    public Connection connection1, connection2;
    public int connection1port = -1, connection2port = -1;

    public Cable(Vector2 point1, Vector2 point2, int connection1, int connection2)
    {
        voltage = 0;
        coordinates = new List<Vector2>();
    }
}