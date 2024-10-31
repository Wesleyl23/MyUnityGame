using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public float spawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBird", 0f, spawnInterval);
    }

    // Update is called once per frame
    void SpawnBird ()
    {
        Instantiate(birdPrefab);
    }
}
