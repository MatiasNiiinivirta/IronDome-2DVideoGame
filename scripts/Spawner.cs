using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoint;

    private int rand;
    private int randPosition;
    public float startTimeBtwSpawns;
    private float timeBtwSpawns;


    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
        InvokeRepeating("Tick", 20, 20);
    }

    private void Update()
    {

        // As startTime increases, different types of enemies spawn to increase game difficulty over time

        if (timeBtwSpawns <= 0)
        {
            if (startTimeBtwSpawns >= 3f)
            {
                rand = Random.Range(4, enemies.Length);
                randPosition = Random.Range(0, spawnPoint.Length);
                Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else if (startTimeBtwSpawns > 2.5f) 
            {
                rand = Random.Range(3, enemies.Length);
                randPosition = Random.Range(0, spawnPoint.Length);
                Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else if (startTimeBtwSpawns > 2f) 
            {
                rand = Random.Range(2, enemies.Length);
                randPosition = Random.Range(0, spawnPoint.Length);
                Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else if (startTimeBtwSpawns > 1.5f)
            {
                rand = Random.Range(1, enemies.Length);
                randPosition = Random.Range(0, spawnPoint.Length);
                Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else 
            {
                rand = Random.Range(0, enemies.Length);
                randPosition = Random.Range(0, spawnPoint.Length);
                Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
                timeBtwSpawns = startTimeBtwSpawns;
            }
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }

      
    }
     public void Tick()
    {

        startTimeBtwSpawns -= 0.1f;
 
    }
}
