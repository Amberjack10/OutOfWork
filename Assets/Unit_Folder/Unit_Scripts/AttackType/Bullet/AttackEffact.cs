using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffact : MonoBehaviour
{
    AttackBase attackBase;
    Animator animator;

    public GameObject effect;

    private void Start()
    {
        attackBase = GetComponentInParent<AttackBase>();

        attackBase.OnAttackEvent += ShowEffact;
        attackBase.OnAttackEndEvent += EndEffect;
    }

    private void EndEffect()
    {
        effect.SetActive(false);
    }

    private void ShowEffact()
    {
        effect.SetActive(true);

        animator = effect.GetComponent<Animator>();
        animator.SetTrigger("ShowEffect");
    }

}
