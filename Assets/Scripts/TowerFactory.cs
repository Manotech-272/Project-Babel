using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] GameObject turret;
    [SerializeField] Transform towerParentTransform;

    [Range(1,50)][SerializeField] int towerLimit;

    Queue<Tower> towers = new Queue<Tower>();
    
    public void AddTower(Waypoint baseWaypoint)
    {
        if (towers.Count < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
        
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var towerWaypoint = Instantiate(turret, baseWaypoint.transform.position, Quaternion.identity);
        Tower tower = towerWaypoint.transform.Find("Tower").GetComponent<Tower>();

        towerWaypoint.transform.parent = towerParentTransform;

        towers.Enqueue(tower);
        Destroy(baseWaypoint.gameObject);
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        var tower = towers.Dequeue();
        var towerWaypoint = tower.GetComponentInParent<Waypoint>();

        var temp = towerWaypoint.transform.position;

        towerWaypoint.transform.position = baseWaypoint.transform.position;  // Move the tower to the new position

        baseWaypoint.transform.position = temp;  // Move the empty Waypoint to the old position of the tower (Avoid creating and destroying waypoints)

        towers.Enqueue(tower);
    }
}
