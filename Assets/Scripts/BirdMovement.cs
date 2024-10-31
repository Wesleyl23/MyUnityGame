using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float speed = 2f;
    public float spawnX = 10f;
    public float endX = -10f;
    public float spawnYRange = 3f;
    // Start is called before the first frame update
    void Start()
    {
        float randomY = Random.Range(-spawnYRange, spawnYRange);
        transform.position = new Vector3(spawnX, randomY, 0);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < endX) 
        {
            Destroy(gameObject);
        }
    }
}
