using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectType;
    public int objectIndex;
    public Transform minpos, maxpos;

    public float startDelay, spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnRandomObject()
    {
        //Random generatw mummy index and spawn position 

        float xpos = Random.Range(minpos.position.x, maxpos.position.x);
        float ypos= minpos.position.y;
        int objectIndex = Random.Range(0, objectType.Length);
        Vector2 spawnPos = new Vector2(xpos, ypos);
        Instantiate(objectType[objectIndex], spawnPos, objectType[objectIndex].transform.rotation);

    }
}
