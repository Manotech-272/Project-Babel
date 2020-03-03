using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColHandler : MonoBehaviour
{
    [SerializeField] int scoreValue = 500;
    [SerializeField] int healthPoints = 3;

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    private bool isAlive;

    public bool IsAlive { get { return isAlive; } }

    void Start()
    {
        isAlive = true;
        AddNonTriggerBoxCollider();
    }

   
    void Update()
    {
        
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider col = gameObject.AddComponent<BoxCollider>();
        col.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessDamage();
        if (healthPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessDamage()
    {
        healthPoints--;
    }

    private void KillEnemy()
    {
        isAlive = false;
        GameObject FX = Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
