using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemy;
    [Range(1f,120f)][SerializeField] int noOfEnemies;
    void Start()
    {
        StartCoroutine(SpawnEnemy(noOfEnemies));
    }

    

    void Update()
    {
        
    }

    public IEnumerator SpawnEnemy(int n)
    {
        for(int i = 0; i<n; i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
