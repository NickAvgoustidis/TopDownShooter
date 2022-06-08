using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [HideInInspector] public Shooter shooter;
    [HideInInspector] public Mover mover;

    public override void Awake()
    {
        base.Awake();
        shooter = GetComponent<Shooter>();
        mover = GetComponent<Mover>();

    }





}
