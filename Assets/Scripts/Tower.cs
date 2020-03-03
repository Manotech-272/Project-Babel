using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    public GameObject bullets;
    
    // Update is called once per frame
    void Update()
    {
        if (targetEnemy.GetComponent<EnemyColHandler>().IsAlive)
        {
            Track();
            IsAttacking(true);
        }
        else
        {
            IsAttacking(false);
        }

    }

    private void Track()
    {
        objectToPan.LookAt(targetEnemy);
    }

    private void IsAttacking(bool yes)
    {
        bullets.SetActive(yes);
    }
}
