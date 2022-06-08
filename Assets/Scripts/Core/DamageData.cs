using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DamageData
{
    public float damage;
    public float critChance;
    public float critDamage;

    public DamageData(float damage, float critChance, float critDamage)
    {
        this.damage = damage;
        this.critChance = critChance;
        this.critDamage = critDamage;
    }

    public float totalDamage()
    {
        bool isCrit = Random.Range(0, 100) >= critChance;

        if (isCrit)
        {
            damage = Mathf.CeilToInt(damage * critDamage);
        }

        return damage;
    }
    
}
