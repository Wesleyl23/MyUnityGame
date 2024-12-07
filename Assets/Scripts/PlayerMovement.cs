using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool isFacingRight = true;
    public Animator animator;
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
        float overallSpeed = new Vector2(moveX, moveY).magnitude;

        animator.SetFloat("Speed", Mathf.Abs(overallSpeed));

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