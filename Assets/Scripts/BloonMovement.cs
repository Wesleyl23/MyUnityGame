using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonMovement : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(Random.Range(-1f, -1f), Random.Range(-1f, -1f)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x > Screen.width / 2 || transform.position.x < -Screen.height / 2) 
        {
            direction.x = -direction.x;
        }

        if (transform.position.y > Screen.width / 2 || transform.position.y < -Screen.height / 2)
        {
            direction.y = -direction.y;
        }

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x > Screen.width || screenPosition.x < 0 ||
           screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            direction = -direction;
        }
    }
}
