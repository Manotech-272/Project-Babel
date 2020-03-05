using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Range(1,50)]  [SerializeField] float enemySpeed = 2f;
    [Range(1, 50)] [SerializeField] int damageToBase = 1;

    BaseHealth baseH;

    private void Awake()
    {
        baseH = FindObjectOfType<BaseHealth>();
    }
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
           
            yield return new WaitForSeconds(1/enemySpeed *2);

        }

        StartGoalReachedSequence();
        
        
    }

    private void StartGoalReachedSequence()
    {
        SendMessage("ReachedEnemyBaseSequece");
        baseH.ProcessBaseDamage(damageToBase);
    }

    void Update()
    {
       
        
    }


    

}
