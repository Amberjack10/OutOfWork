using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : AttackBase
{
    private int attack;
    private string opponentTag;

    private UnitBase unitBase;

    private void Start()
    {
        unitBase = GetComponentInParent<UnitBase>();

        attack = unitBase.attack;
        opponentTag = unitBase.opponentTag;
    }

    protected void OnShootLaser()
    {
        CallAttackEvent();
    }

    protected void EndAttack()
    {
        CallAttackEndEvent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(opponentTag))
        {
            collision.GetComponent<IDamageable>().TakeDamage(attack);
        }
    }
}
