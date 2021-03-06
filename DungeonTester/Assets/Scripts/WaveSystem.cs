﻿using UnityEngine;
using System.Collections;

public class WaveSystem : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown = 0f;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;

        if (spawnPoints.Length == 0)
            Debug.Log("No Spawn Points Set");

    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
                
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine( SpawnWave( waves[nextWave] ) );
            }
        }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
           

        void WaveCompleted()
        {
            Debug.Log("Wave finished");
            state = SpawnState.COUNTING;
            waveCountdown = timeBetweenWaves;


            if(nextWave + 1 > waves.Length - 1)
            {
                
                //nextWave = 0;
                Debug.Log("All Waves complete. Looping...");

                GameMaster GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
                
                GM.enterLevel(1);

            }

            else { nextWave++; }
            

        }

        bool EnemyIsAlive()
        {
            searchCountdown -= Time.deltaTime;

            if (searchCountdown <= 0f)
            {
                searchCountdown = 1f;
                if (GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    return false;
                }
            }
            return true;
        }

        IEnumerator SpawnWave(Wave _wave)
        {
            Debug.Log("Spawning " + _wave.name);
            state = SpawnState.SPAWNING;

            for (int i = 0; i < _wave.count; i++)
            {
                SpawnEnemy(_wave.enemy);
                yield return new WaitForSeconds( 1f / _wave.rate );
            }

            state = SpawnState.WAITING;

            yield break;
        }

        void SpawnEnemy(Transform _enemy)
        {
            // Spawn enemy
            Debug.Log("Spawn Enemy: " + _enemy.name);

            

            Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(_enemy, _sp.position, _sp.rotation);
            
        }
    }

}
