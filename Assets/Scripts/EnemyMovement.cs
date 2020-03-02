﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   
    void Start()
    {
        

        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }



    IEnumerator FollowPath(List<Waypoint> path)
    {
        
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
           
            yield return new WaitForSeconds(1);

        }
        // Debug.Log("Ending patrol");
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }


    

}
