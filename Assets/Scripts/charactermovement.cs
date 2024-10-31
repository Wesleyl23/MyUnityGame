using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool isFacingRight= false;
  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.gravityScale = 0f;
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found! Ensure the object has a Rigidbody2D component.");
        }    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
    }
    void MoveCharacter() 
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        if (moveX > 0 && !isFacingRight)
        {
            FlipSprite();
        }
        else if (moveX < 0 && isFacingRight) 
        {
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
}