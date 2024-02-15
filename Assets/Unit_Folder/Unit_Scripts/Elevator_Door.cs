using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Door : MonoBehaviour, IDamageable
{
    public int maxHealth;
    private int currentHealth;

    [HideInInspector]public bool isDestroyed = false;

    protected Animator animator;

    public float HealthRate 
    {
        get { return (float)(currentHealth / maxHealth); } 
    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        currentHealth = maxHealth;

        StageManager.instance.elevator = gameObject;
    }

    public void SetHP()
    {
        currentHealth = maxHealth;
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
        StageManager.instance.StageClear();

        while (animator.IsInTransition(0) == false)
        {
            yield return new WaitForEndOfFrame();
        }

    }
}
