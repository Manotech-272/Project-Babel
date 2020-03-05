using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    
    
    [SerializeField] GameObject bullets;
    [SerializeField] float shootingRange = 60;


    Transform targetEnemy;

  
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            if (EnemyIsInRange())
            {
                Track(targetEnemy);
                IsAttacking(true);
            }
            else
            {
                IsAttacking(false);
            }
            
        }
        else
        {
            //print("IsNotAttacking");
            IsAttacking(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyHealthHandler>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach(EnemyHealthHandler testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        float dist1 = TwoDimDistance(transform.position, transformA.position);
        float dist2 = TwoDimDistance(transform.position, transformB.position);

        Transform closest = dist1 < dist2 ? transformA : transformB;

        return closest;
    }

    private bool EnemyIsInRange()
    {
        bool inRange = false;
        

        float dist = TwoDimDistance(transform.position, targetEnemy.position);

        if (dist < shootingRange)
        {
            inRange = true;
        }
        return inRange;
    }

    private void Track(Transform target)
    {
        objectToPan.LookAt(target.Find("TurretTarget"));
        
    }

    private void IsAttacking(bool active)
    {
        var emissionModule = bullets.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = active;
    }

    private float TwoDimDistance(Vector3 v1, Vector3 v2)
    {
        return Vector2.Distance(new Vector2(v1.x, v1.z), new Vector2(v2.x, v2.z));
    }
}
