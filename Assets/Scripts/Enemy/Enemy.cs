using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MoveableObject
{

    [SerializeField] float speed = 5;
    [SerializeField] float baseHealth = 20;
    private Transform player;
    Health health;

    public Action<Enemy> OnEnemyDeath;

    public override void Awake()
    {
        base.Awake();
        health = GetComponent<Health>();
        health.OnDeath.AddListener(Die);
        
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        GameManager.Instance.AddEnemyOnSpawn(this);
        health.SetHealth(baseHealth * GameInformation.CurrentGameDifficulty);
    }

    void Die()
    {
        OnEnemyDeath?.Invoke(this);
    }

    public override void HandleMove()
    {
        mover.MoveTowards(player.position, speed);
    }
}
