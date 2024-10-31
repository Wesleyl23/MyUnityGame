using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinMovement : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody2D rb;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontally();
    }

    void MoveHorizontally() 
    {
        Vector2 moveDirection = new Vector2(speed * Time.deltaTime, 0);

        rb.MovePosition(rb.position + moveDirection);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("balloon"))
        {

            float balloonSize = collision.transform.localScale.x;
            int points = CalculateScore(balloonSize);
            ScoreManager.instance.AddScore(points);

            AudioSource balloonAudioSource = collision.GetComponent<AudioSource>();
            if (balloonAudioSource != null)
            {
                balloonAudioSource.Play();
            }

            Destroy(collision.gameObject, 0.2f);

            Destroy(gameObject);
        }
        else if (collision.CompareTag("Bird"))
        {
            HandleBirdCollision();

            Destroy(gameObject);
        }
    }

    void HandleBirdCollision() 
    {
        if (scoreManager != null) 
        {
            scoreManager.DeductPoints(10);
        }

        Debug.Log("No animal cruelty! You lose 10 points!");
    }
    int CalculateScore(float size)
    {
        if (size < 0.5f) return 100;
        if (size < 1f) return 50;
        return 25;
    }
}