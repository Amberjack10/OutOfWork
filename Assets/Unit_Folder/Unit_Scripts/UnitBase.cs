using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum UnitState
{
    Idle,
    Walking,
    Attacking,
    Dead
}

public class UnitBase : MonoBehaviour, IDamageable
{
    protected static readonly int IsWalking = Animator.StringToHash("IsWalking");
    protected static readonly int Attack = Animator.StringToHash("Attack");
    protected static readonly int Dead = Animator.StringToHash("Dead");

    [HideInInspector]public string opponentTag;
    protected bool isPlayerUnit;
    protected bool foundEnemy = false;
    [HideInInspector] protected bool isDead = false;

    [HideInInspector]public Vector2 moveDirection;
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

    protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        SetState(UnitState.Idle);
        SetOppoenet();
        SetDitrection();
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------
    //Setting Function

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

    public void SetDitrection()
    {
        if (!isPlayerUnit)
        {
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
            moveDirection = Vector2.left;
        }
        else
        {
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.y);
            moveDirection = Vector2.right;
        }
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
            case UnitState.Dead:
                _rigidbody.velocity = Vector2.zero;
                animator.SetBool(IsWalking, false);
                break;
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------

    protected void Start()
    {
        
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------
    //Update Function

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
            case UnitState.Dead:
                StartCoroutine("Die");
                break;
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
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
                float animTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
                if(animTime == 0 || animTime > 1f)
                {
                    SetState(UnitState.Idle);
                }
            }
            else
            {
                SetState(UnitState.Idle);
            }
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

    //--------------------------------------------------------------------------------------------------------------------------------------------------
    //Acting Function

    public void Move_Unit()
    {

        _rigidbody.velocity = moveDirection * walkSpeed;
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            SetState(UnitState.Dead);
        }
    }

    IEnumerator Die()
    {
        isDead = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        animator.SetTrigger(Dead);

        while(animator.IsInTransition(0) == false)
        {
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------
    //Collision

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(opponentTag) && !collision.GetComponent<UnitBase>().isDead)
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

}
