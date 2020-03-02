using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] Color exploredColor;


    const int unitGridSize = 10;

    Vector2Int gridPos;

    public Waypoint parent;

    public bool isExplored = false;

    void Start()
    {
        
    }

    
    public int GetUnitGridSize()
    {
        return unitGridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / unitGridSize) ,
                Mathf.RoundToInt(transform.position.z / unitGridSize)
                    );
    }

    public void SetTopColor(Color color)
    {
        transform.Find("Up").GetComponent<MeshRenderer>().material.color = color;
    }

    void Update()
    {
        if (isExplored)
        {
            SetTopColor(exploredColor);
        }
    }
}
