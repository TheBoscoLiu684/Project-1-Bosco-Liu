using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class HazardSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> randomItems = new List<GameObject>();
    public float minTime = 0.5f;
    public float maxTime = 5f;
    public float timer = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {

        }

    }

    public void ResetTimer()
    {

    }
    public void SpawnThing()
    {
        
    }
}
