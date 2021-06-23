using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    public GameObject platformPrefab;

    public int NumberOfPlatforms;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        //set spawnposition to be a new vector3
        Vector3 spawnPosition = new Vector3();
        //for the number of platforms 
        for (int i = 0; i < NumberOfPlatforms; i++)
        {
            //set each spawn y position to be between min and max y
            spawnPosition.y += Random.Range(minY, maxY);
            //set each spawn x position to be between min and max x
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            //instantiate platforms with the given spawnpositions  
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
