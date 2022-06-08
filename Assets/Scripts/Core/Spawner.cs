using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    enum SpawnState { Spawning, Waiting }

    SpawnState state = SpawnState.Waiting;
    [SerializeField] GameObject enemy;
    [SerializeField] float timeBetweenSpawns = 3;
    [SerializeField] float range = 3;
    
    Transform player;

    private void Start()
    {
        player = Player.Instance.transform;


        StartCoroutine(Spawn());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = state == SpawnState.Spawning ? state = SpawnState.Waiting : state = SpawnState.Spawning;
        }
    }

    public void StartSpawning()
    {
        state = SpawnState.Spawning;
    }

    public void StopSpawning()
    {
        state = SpawnState.Waiting;
    }


    IEnumerator Spawn()
    {

        while (true)
        {
            
            switch (state)
            {
                case SpawnState.Spawning:

                    Vector2 randomPos = (Random.insideUnitCircle + (Vector2)player.position) * range;

                    Instantiate(enemy, randomPos, Quaternion.identity);

                    yield return new WaitForSeconds(timeBetweenSpawns);


                    break;

                case SpawnState.Waiting:
                    break;
                default:
                    break;
            }


            yield return new WaitUntil(() => GameManager.GameState == GameState.PLAYING);
            yield return null;
        }



    }

  
}


