using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : AttackBase
{
    private int attack;
    private string opponentTag;

    public BoxCollider2D attackRange;

    private UnitBase unitBase;

    private void Start()
    {
        unitBase = GetComponentInParent<UnitBase>();

        attack = unitBase.attack;
        opponentTag = unitBase.opponentTag;
    }

    protected void OnHit()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(attackRange.transform.position, attackRange.size, 0);
        CallAttackEvent();

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(opponentTag))
            {
                collider.GetComponent<IDamageable>().TakeDamage(attack);
            }
        }
    }

    protected void EndAttack()
    {
        CallAttackEndEvent();
    }

}
