using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : BulletBase
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(rangeAttackData.opponentTag))
        {
            collision.GetComponent<IDamageable>().TakeDamage(rangeAttackData.attack);
        }
    }
}
