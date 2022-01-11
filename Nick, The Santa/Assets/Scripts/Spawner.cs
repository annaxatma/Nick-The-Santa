using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public int mobCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawn()
    {
        for (int i = 0; i < mobCount; i++) 
        {
             int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawPoint].position, transform.rotation);
        }
           
    }
    
}
