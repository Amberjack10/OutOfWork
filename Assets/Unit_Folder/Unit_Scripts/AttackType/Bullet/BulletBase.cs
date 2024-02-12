using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    protected bool isRadey;
    protected string opponentTag;
    protected float bulletSpeed;
    protected int attack;
    protected float currentDuration;

    protected Vector2 bulletDirection;
    protected Rigidbody2D _rigidbody2D;

    protected RangeAttackData rangeAttackData;

    protected void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        if (!isRadey)
        {
            return;
        }

        currentDuration += Time.deltaTime;

        if (currentDuration >= rangeAttackData.duration)
        {
            DestroyBullet();
        }

        _rigidbody2D.velocity = rangeAttackData.shootDirection * rangeAttackData.bulletSpeed;
    }

    protected void DestroyBullet()
    {
        gameObject.SetActive(false);
    }

    public void InitiateBullet(RangeAttackData data)
    {
        rangeAttackData = data;
        currentDuration = 0;
        isRadey = true;
    }
}
