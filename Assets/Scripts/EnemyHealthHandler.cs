using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour
{

    [SerializeField] int scoreValue = 500;
    [SerializeField] int healthPoints = 3;

    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitFX;

    [SerializeField] Transform effectsPosition;

    [SerializeField] SimpleHealthBar healthBar;

    [SerializeField] Color Full;
    [SerializeField] Color Middle;
    [SerializeField] Color Low;

    Transform cameraTransform;

    private bool isAlive;

    float maxHealth;

    public bool IsAlive { get { return isAlive; } }


    private void Awake()
    {
        cameraTransform = FindObjectOfType<Camera>().transform;
    }

    void Start()
    {
        isAlive = true;
        maxHealth = healthPoints;
       
    }


    private void Update()
    {
        UpdateHealthBar();
        TurnHealthBarToCamera();
    }

    private void TurnHealthBarToCamera()
    {
        healthBar.gameObject.transform.parent.parent.LookAt(cameraTransform);
        print(healthBar.gameObject.transform.parent.parent.name);
    }

    private void UpdateHealthBar()
    {
        healthBar.UpdateBar(healthPoints, maxHealth);

        if (healthPoints > 3 * maxHealth / 4)
        {
            healthBar.UpdateColor(Full);
        }

        if (healthPoints > maxHealth / 4 && healthPoints < 3 * maxHealth / 4)
        {
            healthBar.UpdateColor(Middle);
        }

        if (healthPoints < maxHealth / 4)
        {
            healthBar.UpdateColor(Low);
        }
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
        hitFX.GetComponent<ParticleSystem>().Play();
        healthPoints--;
    }


    public void ReachedEnemyBaseSequece()
    {
        
        KillEnemy();
    }

    private void KillEnemy()
    {
        isAlive = false;
        GameObject FX = Instantiate(deathFX, effectsPosition.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
