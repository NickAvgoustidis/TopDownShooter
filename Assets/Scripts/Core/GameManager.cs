using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState { PLAYING, PAUSED }

public class GameManager : Singleton<GameManager>
{
    public static GameState GameState = GameState.PLAYING;

    [SerializeField] int increaseDifficultyEveryAmountOfEnemies = 10;
    [SerializeField] List<Enemy> aliveEnemies = new List<Enemy>();

 [SerializeField]   int TotalEnemiesEncountered = 0;

    public void AddEnemyOnSpawn(Enemy enemy)
    {
        aliveEnemies.Add(enemy);
        enemy.OnEnemyDeath += RemoveEnemyOnDeath;
        TotalEnemiesEncountered++;

        IncreaseDifficulty();

    }

   public void RemoveEnemyOnDeath(Enemy enemy)
    {
        enemy.OnEnemyDeath -= RemoveEnemyOnDeath;
        aliveEnemies.Remove(enemy);
    }


    void IncreaseDifficulty()
    {
        if(TotalEnemiesEncountered % increaseDifficultyEveryAmountOfEnemies == 0)
        {
            Debug.Log("Inrease Difficulty");
           
            GameInformation.IncreaseDifficulty();
        }
    }
}
