using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : Bullet
{
    [SerializeField] LayerMask enemyMask;
    int targets = 1;

    public override void SetDmgDone(DamageData damageData, int targets)
    {
        this.targets = targets;
        base.SetDmgDone(damageData, targets);

    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health health))
        {
            StopBulletLife();


            Explode(other);

            
        }
        else
        {
            Destroy(gameObject, 5);
        }

    }


    void Explode(Collider2D other)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 4, Vector2.up, enemyMask);

        List<Health> hitables = new List<Health>();
        foreach (var enemy in hits)
        {
            if (!enemy.transform.CompareTag("Enemy")) continue;
            Health enemyHealth = enemy.transform.GetComponent<Health>();
            hitables.Add(enemyHealth);

        }

        if(hitables.Count > 0)
        {
            if (hitables.Count <= targets)
            {
                targets = hitables.Count;
            }


            Debug.Log("It hit");


            for (int i = 0; i < targets; i++)
            {
                hitables[i].TakeDamage(damageData.totalDamage());
            }
        }

        
        Destroy(gameObject);
    }
}
