using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Door : MonoBehaviour, IDamageable
{
    public int maxHealth;
    [SerializeField]private int currentHealth;

    public bool isDestroyed = false;

    protected Animator animator;

    public float HealthRate 
    {
        get { return (float)(currentHealth / maxHealth); } 
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();
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

        while (animator.IsInTransition(0) == false)
        {
            yield return new WaitForEndOfFrame();
        }

    }
}
