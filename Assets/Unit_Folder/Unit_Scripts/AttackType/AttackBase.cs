using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    public event Action OnAttackEvent;
    public event Action OnAttackEndEvent;

    public AudioClip attackClip;

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

    public void CallAttackEndEvent()
    {
        OnAttackEndEvent?.Invoke();
    }
}
