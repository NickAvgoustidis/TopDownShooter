using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MoveableObject
{
    //Movement
    [SerializeField] private float moveSpeed;
    Camera mainCam;

    //Aim
    [SerializeField] private Transform gun;
       
    Shooter shooter;

    public override void Awake()
    {
        base.Awake();

        shooter = GetComponent<Shooter>();
        mainCam = Camera.main;
    }


    public override void Update()
    {
        //MOVEMENT and AIM
        base.Update();
       HandleRotation();

        //Shoot
        HandleShooting();

    }

    private void HandleShooting()
    {

        shooter.Shoot(gun);
    
    }

    private void HandleRotation()
    {
        var direction = Input.mousePosition - mainCam.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

       gun.rotation = rotation;
    }

    public override void HandleMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(x, y);

        //    mover.Move(dir, moveSpeed);
        transform.Translate(x * moveSpeed * Time.deltaTime, y * moveSpeed * Time.deltaTime, 0, Space.Self);
       
       
    }

    
}
