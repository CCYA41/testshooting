using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject[] enemyPrefabs;

    public float curEnemySpwanDelay;
    public float nextEnemySpwanDelay;


    void Start()
    {

    }


    void Update()
    {
        curEnemySpwanDelay += Time.deltaTime;
        if (curEnemySpwanDelay > nextEnemySpwanDelay)
        {
            SpwanEnemy();

            nextEnemySpwanDelay = UnityEngine.Random.Range(0.5f, 3.0f);
            curEnemySpwanDelay = 0;
        }
    }

    private void SpwanEnemy()
    {
        int ranEnemy = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        int ranPoint = UnityEngine.Random.Range(0, spawnPoints.Length);

        GameObject goEnemy = Instantiate(enemyPrefabs[ranEnemy], spawnPoints[ranPoint].position, Quaternion.identity);

        EnemyCtrl enemyLogic = goEnemy.GetComponent<EnemyCtrl>();

        enemyLogic.Move(ranPoint);
    }
}
