using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]


public class CubeEditor : MonoBehaviour
{







    [SerializeField] bool isFloor = true;

    Waypoint waypoint;

    public static CubeEditor instance;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        int unitGridSize = waypoint.GetUnitGridSize();

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        if (isFloor)
        {
            string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
            textMesh.text = labelText;
            gameObject.name = labelText;
        }
        
       
    }

    private void SnapToGrid()
    {
        int unitGridSize = waypoint.GetUnitGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x * unitGridSize, 0, waypoint.GetGridPos().y * unitGridSize);
    }
}
