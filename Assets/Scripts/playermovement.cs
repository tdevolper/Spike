using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private Rigidbody2D rb;


    private float dirX = 0f;
    [SerializeField]
    private float movespeed = 1f;
    [SerializeField]
    private float jumpForce = 1f;

    bool isFacing = true;

    public Transform groundCheck;
    [SerializeField]
    private float groundLimted = 0.2f;
    public LayerMask WhereIsGround;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        flip();
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX*movespeed, rb.velocity.y);
    }
    void flip()
    {
        if(isFacing && dirX < 0 || !isFacing && dirX > 0)
        {
            isFacing = !isFacing;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundLimted, WhereIsGround);
    }
}
