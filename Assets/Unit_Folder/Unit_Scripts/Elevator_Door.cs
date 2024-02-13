using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Door : MonoBehaviour, IDamageable
{
    public int maxHealth;
    private int currentHealth;

    public bool isDestroyed = false;

    public float HealthRate 
    {
        get { return (float)(currentHealth / maxHealth); } 
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        if(currentHealth <= 0)
        {
            isDestroyed = true;
        }
    }
}
