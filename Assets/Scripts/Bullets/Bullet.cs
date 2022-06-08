using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MoveableObject
{
    
    [SerializeField] protected float bulletSpeed = 10;

    protected Vector2 direction;
    protected DamageData damageData;
    bool hitSomething = false;
    Coroutine bulletLifeCoroutine;
    public virtual void SetDmgDone(DamageData damageData, int targets = 1)
    {
        this.damageData = damageData;
    }

    public override void HandleMove()
    {
        mover.Move(direction, bulletSpeed);
    }

    public  void Start()
    {
        
        direction = Vector2.up;
        StartBulletLife();
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Health health))
        {
            StopBulletLife();
            health.TakeDamage(damageData.totalDamage());
            Destroy(gameObject);
        }
    }

    protected void StartBulletLife()
    {
       bulletLifeCoroutine =  StartCoroutine(BulletLife());
    }

    protected void StopBulletLife()
    {
        if(bulletLifeCoroutine != null)
        {
            StopCoroutine(bulletLifeCoroutine);
            bulletLifeCoroutine = null;
        }
    }

    IEnumerator BulletLife()
    {
        float timetillDestroy = 5;
        float timer = 0;

        while (!hitSomething)
        {
            timer += Time.deltaTime;
            if(timer >= timetillDestroy)
            {
                break;
            }
            yield return null;
        }

        Destroy(gameObject);
    }
}
