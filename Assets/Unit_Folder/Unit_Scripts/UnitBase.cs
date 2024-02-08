using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum UnitState
{
    Idle,
    Walking,
    Attacking
}

public class UnitBase : MonoBehaviour
{
    protected bool isPlayerUnit;
    protected bool foundEnemy = false;

    private Vector2 moveDirection;
    private Rigidbody2D _rigidbody;
    public LayerMask layermask;

    protected UnitState state;

    [Header("Stat")]
    public int health;
    public float walkSpeed;
    public int attack;
    public float attackRate;
    private float attackLastTime;

    private Collider2D attackRange;

    protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }

    protected void Start()
    {
        state = UnitState.Idle;
        attackRange = transform.Find("AttackRange").GetComponent<Collider2D>();
    }

    protected void Update()
    {
        
    }

    protected void UpdatePassive()
    {
        if (foundEnemy)
        {
            state = UnitState.Attacking;
        }
        else
        {
            state = UnitState.Walking;
        }
    }

    protected virtual void UpdateWalking()
    {
        if (foundEnemy)
        {
            state = UnitState.Attacking;
        }
        else
        {
            Move_Unit();
        }
    }

    public void Move_Unit()
    {
        if(isPlayerUnit == false)
        {
            moveDirection = Vector2.left;
        }
        else
        {
            moveDirection = Vector2.right;
        }

        _rigidbody.velocity = moveDirection * walkSpeed;
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
