using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 600f;
    public float maxSpeed = 8f;
    public float idleFriction = 0.9f;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 ||
            Input.GetAxisRaw("Horizontal") == -1 ||
            Input.GetAxisRaw("Vertical") == 1 ||
            Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastMoveHorizontal",
                              Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastMoveVertical",
                              Input.GetAxisRaw("Vertical"));
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(movement * moveSpeed * Time.deltaTime);
        if(rb.velocity.magnitude > maxSpeed)
        {
            float limitedSpeed = Mathf.Lerp(rb.velocity.magnitude, maxSpeed, idleFriction);
            rb.velocity = rb.velocity.normalized * limitedSpeed;
        }
        if(movement == new Vector2(0,0))
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
        }
    }
}
