using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] Color Full;
    [SerializeField] Color Middle;
    [SerializeField] Color Low;


    [Range(10, 100)] [SerializeField] float health = 10;
    [SerializeField] SimpleHealthBar healthBar;
    float maxHealth;


    private void Start()
    {
        maxHealth = health;
    }

    public void ProcessBaseDamage(int damage)
    {
        health = health - damage;
       
    }

    private void Update()
    {
        UpdateHealthBar();

    }

    private void UpdateHealthBar()
    {
        healthBar.UpdateBar(health, maxHealth);

        
        
        if (health > 3 * maxHealth / 4)
        {
            healthBar.UpdateColor(Full);
            
        }

        if (health > maxHealth / 4 && health < 3 * maxHealth / 4)
        {
            healthBar.UpdateColor(Middle);
            
        }

        if (health < maxHealth / 4)
        {
            healthBar.UpdateColor(Low);
            
        }
        
    }
}
