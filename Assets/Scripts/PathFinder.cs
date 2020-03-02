using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] [Tooltip("The start point")] Waypoint startWaypoint;
    [SerializeField] [Tooltip("The end point")] Waypoint endWaypoint;


    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};

    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool isRunning = true;
    Waypoint searchCentre;

    List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> Path { get { return this.path; } }

    void Start()
    {
        
    }

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }


    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = GetComponentsInChildren<Waypoint>();
        print(waypoints.Length);
        foreach(Waypoint waypoint in waypoints)
        { 
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.Log("Skipping overlapping block" + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }

    // Update is called once per frame
    protected void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        Waypoint currentWaypoint = queue.Peek();

        while (queue.Count > 0 && isRunning)
        {
            searchCentre = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCentre.isExplored = true;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }

        foreach (var direc in directions)
        {
            Vector2Int explorationCoordinates = searchCentre.GetGridPos() + direc;
            if (grid.ContainsKey(explorationCoordinates))
            {
                QueueNewNeighbours(explorationCoordinates);
            }
            
        }
    }

    private void QueueNewNeighbours(Vector2Int explorationCoordinates)
    {
        Waypoint neighbour = grid[explorationCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            // do nothing
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.parent = searchCentre;
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCentre.Equals(endWaypoint))
        {
            isRunning = false;

        }
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);

        Waypoint previous = endWaypoint.parent;
        
        while (!previous.Equals(startWaypoint))
        {
            path.Add(previous);
            previous = previous.parent;
        }

        path.Add(startWaypoint);
        path.Reverse();
    }
}
