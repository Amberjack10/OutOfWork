using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackData
{
    public int attack;
    public string opponentTag;
    public float bulletSpeed;
    public float duration;

    public Vector2 shootDirection;
}

public class RangeAttack : AttackBase
{
    private RangeAttackData rangeAttackData;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDuration;

    public Transform shootPoint;

    private UnitBase unitBase;

    private BulletPool bulletPool;

    private void Start()
    {
        unitBase = GetComponentInParent<UnitBase>();
        rangeAttackData = new RangeAttackData();

        rangeAttackData.attack = unitBase.attack;
        rangeAttackData.opponentTag = unitBase.opponentTag;
        rangeAttackData.bulletSpeed = bulletSpeed;
        rangeAttackData.duration = bulletDuration;

        rangeAttackData.shootDirection = unitBase.moveDirection;

        bulletPool = GetComponent<BulletPool>();
    }

    protected void OnShoot()
    {
        GameObject obj = bulletPool.SpawnObject("normal_bullet");

        obj.transform.position = shootPoint.position;

        BulletBase bullet = obj.GetComponent<BulletBase>();
        bullet.InitiateBullet(rangeAttackData);
        SoundManager.instance.PlaySFX(attackClip);

        obj.SetActive(true);
    }
}
