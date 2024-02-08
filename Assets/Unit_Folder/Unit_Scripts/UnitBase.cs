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
    protected static readonly int IsWalking = Animator.StringToHash("IsWalking");
    protected static readonly int Attack = Animator.StringToHash("Attack");
    protected static readonly int Dead = Animator.StringToHash("Dead");

    protected string opponentTag;
    [SerializeField]protected bool isPlayerUnit;
    [SerializeField]protected bool foundEnemy = false;

    private Vector2 moveDirection;
    private Rigidbody2D _rigidbody;

    protected Animator animator;
    protected SpriteRenderer sprite;

    protected UnitState state;

    [Header("Stat")]
    public int health;
    public float walkSpeed;
    public int attack;
    public float attackRate;
    private bool canAttack = true;

    private CircleCollider2D attackRange;

    protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected void Start()
    {
        SetState(UnitState.Idle);
        attackRange = transform.Find("AttackRange").GetComponent<CircleCollider2D>();
        SetOppoenet();
    }

    protected void Update()
    {
        switch (state)
        {
            case UnitState.Idle:
                UpdatePassive();
                break;
            case UnitState.Walking:
                UpdateWalking();
                break;
            case UnitState.Attacking:
                UpdateAttacking();
                break;
        }
    }

    private void SetOppoenet()
    {
        if (gameObject.CompareTag("PlayerUnit"))
        {
            isPlayerUnit = true;
            opponentTag = "EnemyUnit";
        }
        else if (gameObject.CompareTag("EnemyUnit"))
        {
            isPlayerUnit = false;
            opponentTag = "PlayerUnit";
        }
    }

    private void UpdateAttacking()
    {
        if (foundEnemy)
        {
            if (canAttack)
            {
                canAttack = false;
                animator.SetTrigger(Attack);
                Invoke("WaitAttackCoolTime", attackRate);
            }
        }
        else
        {
            SetState(UnitState.Idle);
        }
    }

    protected void WaitAttackCoolTime()
    {
        canAttack = true;
    }

    protected void UpdatePassive()
    {
        if (foundEnemy)
        {
            SetState(UnitState.Attacking);
        }
        else
        {
            SetState(UnitState.Walking);
        }
    }

    protected virtual void UpdateWalking()
    {
        if (foundEnemy)
        {
            SetState(UnitState.Attacking);
        }
        else
        {
            Move_Unit();
        }
    }

    public void Move_Unit()
    {
        if(!isPlayerUnit)
        {
            moveDirection = Vector2.left;
            sprite.flipX = true;
        }
        else
        {
            moveDirection = Vector2.right;
            sprite.flipX = false;
        }

        _rigidbody.velocity = moveDirection * walkSpeed;
    }

    protected void SetState(UnitState newState)
    {
        state = newState;

        switch (state)
        {
            case UnitState.Idle:
                _rigidbody.velocity = Vector2.zero;
                animator.SetBool(IsWalking, false);
                break;
            case UnitState.Walking:
                animator.SetBool(IsWalking, true);
                break;
            case UnitState.Attacking:
                _rigidbody.velocity = Vector2.zero;
                animator.SetBool(IsWalking, false);
                break;
        }
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

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(opponentTag))
        {
            foundEnemy = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(opponentTag))
        {
            foundEnemy = false;
        }
    }

    protected void OnHit()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackRange.transform.position, attackRange.radius, 0);

        foreach(Collider2D collider in colliders)
        {
            if (collider.CompareTag(opponentTag))
            {
                collider.GetComponent<UnitBase>().TakeDamage(attack);
            }
        }
    }
}
