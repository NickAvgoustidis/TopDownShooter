using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float health;


    public float GetHealth => health;
    public float GetCurrentHealth => currentHealth;

    public UnityEvent OnHit;
    public UnityEvent OnDeath;
    
    private float currentHealth;




    void Initialize()
    {
        currentHealth = health;
    }

    public void SetHealth(float newHealth)
    {
        health = newHealth;
        Initialize();
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        OnHit?.Invoke();
      

        Debug.Log($"Hit {gameObject.name}");

        if (currentHealth <= 0)
        {

            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {

        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
