using UnityEngine;

public enum BulletType { Normal, Ricochet, Explosive }

public class Shooter : MonoBehaviour
{
    [SerializeField] private DamageData damageData;
    [SerializeField] private float attackSpeed = 2;
    [SerializeField] Transform muzzle;
    [SerializeField] Bullet bullet;
    [SerializeField] RicochetBullet ricochetBullet;
    [SerializeField] ExplosiveBullet explosiveBullet;

    BulletType bulletType = BulletType.Normal;
    private float nextAttack = 0;
    private int targets = 1;
    bool isShooting;



    private void Start()
    {
        nextAttack = attackSpeed;

    }




    public void SetAttackSpeed(float newAttackSpeed)
    {
        attackSpeed = newAttackSpeed;
    }

    public void SetDamageDone(int newDmg)
    {
        damageData.damage = newDmg;
    }

    public void SetCritChance(float newCritChance)
    {
        damageData.critChance = newCritChance;
    }

    public void SetCritDamage(float newCritDamage)
    {
        damageData.critDamage = newCritDamage;
    }

    public void ChangeBulletType(BulletType type)
    {
        bulletType = type;
    }

    public void SetUpBulletTargets(int targets)
    {
        this.targets = targets;
    }

    public void Shoot(Transform gun)
    {
        if (GameManager.GameState == GameState.PAUSED) return;

        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }

        nextAttack += Time.deltaTime;
        if (isShooting)
        {
            if (nextAttack >= attackSpeed)
            {
                //Shoot
                Bullet newBullet = null;

                switch (bulletType)
                {
                    case BulletType.Normal:
                        newBullet = InstansiateBullet(bullet, gun);
                        break;
                    case BulletType.Ricochet:
                        newBullet = InstansiateBullet(ricochetBullet, gun);
                        break;
                    case BulletType.Explosive:
                        newBullet = InstansiateBullet(explosiveBullet, gun);
                        break;
                    default:
                        break;
                }



                newBullet.SetDmgDone(damageData, targets);
                nextAttack = 0;
            }

        }
    }


    private Bullet InstansiateBullet(Bullet bullet, Transform gun)
    {
        return Instantiate(bullet, muzzle.position, gun.localRotation);
    }


}
