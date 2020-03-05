using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Waypoint : MonoBehaviour
{


    

    const int unitGridSize = 10;

    Vector2Int gridPos;

    public Waypoint parent;

    public bool isExplored = false;

    public bool isPlaceable = true;

    Shader shader;

    [SerializeField] Material red;
    [SerializeField] Material dark;


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

    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        HighlightTargetBlock(true);

        if (CrossPlatformInputManager.GetButtonDown("Fire1") && isPlaceable)
        {
            FindObjectOfType<TowerFactory>().AddTower(this);
            
        }
    }

    private void HighlightTargetBlock( bool highlight)
    {
        if (isPlaceable)
        {
            if (highlight)
            {
                transform.Find("Crate").GetComponent<MeshRenderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
            }
            else
            {
                transform.Find("Crate").GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
            }
        }
        else
        {
            if (highlight)
            {
                transform.Find("Crate").GetComponent<MeshRenderer>().material = red;
            }
            else
            {
                transform.Find("Crate").GetComponent<MeshRenderer>().material = dark;
            }
        }
    }

    private void OnMouseExit()
    {
        HighlightTargetBlock(false);
    }
}

