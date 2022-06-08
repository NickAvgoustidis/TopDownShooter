using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFollow : MonoBehaviour
{

    [SerializeField] Transform floor;
    [SerializeField] Transform extraFloor;

    [SerializeField] float size = 25.6f;
    [SerializeField] float intervalBetweenDirectionCall = .01f;
    float timer;

    Vector2 previousCameraPos;

    [SerializeField] Vector2 direction;
    Transform player;

    private void Awake()
    {

        player = FindObjectOfType<PlayerController>().transform;
    }

    private void Start()
    {
        previousCameraPos = player.position;
    }


    private void Update()
    {

        timer += Time.deltaTime;
        if (timer >= intervalBetweenDirectionCall)
        {
            previousCameraPos = player.position;
            timer = 0;
        }

        direction = ((Vector2)player.position - previousCameraPos).normalized;
        //Moving Up
        if (direction.y >= 1f)
        {
            Debug.Log("MOVE UP");
            if(player.transform.position.y >= floor.position.y + 5)
            {
                extraFloor.position = new Vector2(floor.position.x, floor.position.y + size);

                Transform temp = floor;
                floor = extraFloor;
                extraFloor = temp;
            }

        }
        //Moving Down
        if (direction.y <= -1f)
        {
            Debug.Log("MOVE DOWN");

            if (player.transform.position.y <= floor.position.y - 5)
            {
                extraFloor.position = new Vector2(floor.position.x, floor.position.y - size);

                Transform temp = floor;
                floor = extraFloor;
                extraFloor = temp;
            }
        }

        //Moving Right
        if (direction.x >= 1f)
        {
            Debug.Log("Move Right");

            if (player.transform.position.x >= floor.position.x + 2)
            {
                extraFloor.position = new Vector2(floor.position.x + size, floor.position.y);

                Transform temp = floor;
                floor = extraFloor;
                extraFloor = temp;
            }
        }

        //Moving Left
        if (direction.x <= -1f)
        {
            Debug.Log("Move Left");

            if (player.transform.position.x <= floor.position.x - 2)
            {
                extraFloor.position = new Vector2(floor.position.x - size, floor.position.y);

                Transform temp = floor;
                floor = extraFloor;
                extraFloor = temp;
            }
        }


       

    }

}
