using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using GLTFast;

public class HazardSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] randomItems;
    public Transform[] spawnPoint;
    public float minTime = 0.5f;
    public float maxTime = 4f;
    public float timer = 0f;
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            ResetTimer();
            SpawnThing();
        }

    }

    public void ResetTimer()
    {
        timer = Random.Range(minTime, maxTime);
    }
    public void SpawnThing()
    {
        int random = Random.Range(0, randomItems.Length);
        int randSpawn = Random.Range(0, spawnPoint.Length);
        Instantiate(randomItems[random], spawnPoint[randSpawn].position, spawnPoint[randSpawn].rotation);
    }
}
