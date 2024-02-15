using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : AttackBase
{
    private int attack;
    private string opponentTag;

    public BoxCollider2D DamageBox;

    private UnitBase unitBase;

    private void Start()
    {
        unitBase = GetComponentInParent<UnitBase>();

        attack = unitBase.attack;
        opponentTag = unitBase.opponentTag;
    }

    protected void OnHit()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(DamageBox.bounds.center, DamageBox.size, 0);
        CallAttackEvent();
        SoundManager.instance.PlaySFX(attackClip);

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
