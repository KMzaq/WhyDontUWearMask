using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemy : MonoBehaviour
{
    public float spawnTime = 3f;
    public float curTime;
    public float curTime2;
    float nanido = 30f;
    public GameObject spawnPoints;
    public GameObject [] enemy;
    public GameObject spawnradious;
    int x;
    int size = 3;
    float radius = 15;


    private void Update()
    {
        if (curTime >= spawnTime)
        {
            /////////////////////////
            Vector3 getPoint = Random.onUnitSphere;
            getPoint.z = 0.0f;

            float r = Random.Range(10.0f, radius);

            Vector3 SP = (getPoint * r) + spawnradious.transform.position;
            ///////////////////////
            spawnPoints.transform.position = SP;
            
            ///
            
            x = Random.Range(1, size);
            if (x > 3) x = 3;
            SpawnEnemy(x);
            curTime = 0;
        }
        if (curTime2 >= nanido)
        {
            size += 1;
            curTime2 = 0;
        }
        curTime += Time.deltaTime;
        curTime2 += Time.deltaTime;
    }

    public void SpawnEnemy(int rannum)
    {
        Instantiate(enemy[rannum], spawnPoints.transform.position, Quaternion.identity);
        if(rannum <= 3)
            GameObject.Find("Chracter").GetComponent<Ca_dead>().respawn();
    }
}
