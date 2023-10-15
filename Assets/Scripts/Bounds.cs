using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    LineRenderer lineBounds;
    EdgeCollider2D edge;

    List<Vector2> points = new List<Vector2>();


    void Start()
    {
        edge = GetComponent<EdgeCollider2D>();
        lineBounds = GetComponent<LineRenderer>();

       

        for(int i = 0; i < lineBounds.positionCount; i++)
        {
            points.Add(new Vector2(lineBounds.GetPosition(i).x, lineBounds.GetPosition(i).y));
        }

        edge.points = points.ToArray();


    }

    
    
}
