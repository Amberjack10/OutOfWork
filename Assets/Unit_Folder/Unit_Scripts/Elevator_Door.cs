using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Door : MonoBehaviour, IDamageable
{
    public int maxHealth;
    [SerializeField]private int currentHealth;

    [HideInInspector]public bool isDestroyed;

    protected Animator animator;

    public float HealthRate 
    {
        get { return ((float)currentHealth / (float)maxHealth); } 
    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        isDestroyed = false;
    }


    public void SetHP()
    {
        currentHealth = maxHealth;
    }

    public float GetHealthRate()
    {
        float healthRate = (float)(currentHealth / maxHealth);
        return healthRate;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        if(currentHealth <= 0)
        {
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        isDestroyed = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        animator.SetTrigger("Open");

        while (true)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("dead_idle"))
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("end");
        StageManager.instance.StageClear();
    }
}
