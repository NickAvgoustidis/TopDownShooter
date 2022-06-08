using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetBullet : Bullet
{
    [SerializeField] LayerMask enemyMask;
    [SerializeField] List<Transform> enemies;
    [SerializeField] List<Transform> alreadyHit = new List<Transform>();
    [SerializeField] int targets = 2;
    int countTargets = 0;


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

            countTargets++;
            if (countTargets >= targets)
            {
                Destroy(gameObject);
                return;
            }
            alreadyHit.Add(other.transform);

            MoveToNextTarget(other, health);

            health.TakeDamage(damageData.totalDamage());
        }
        else
        {
            Destroy(gameObject, 5);
        }

    }


    void MoveToNextTarget(Collider2D other, Health health)
    {


        damageData.damage -= damageData.damage * .25f;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 3, Vector2.up, enemyMask);
        transform.position = other.transform.position;
        Debug.Log("It hit");
        if (enemies.Count > 0) enemies.Clear();

        foreach (var enemy in hits)
        {
            if (!enemy.transform.CompareTag("Enemy") || alreadyHit.Contains(enemy.transform)) continue;
            enemies.Add(enemy.transform);
        }

        if (enemies.Count > 0)
        {
            Transform nextTarget = enemies[0].transform;
            Vector2 newDirection = (Vector2)nextTarget.position - (Vector2)transform.position;
            float angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = q;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
