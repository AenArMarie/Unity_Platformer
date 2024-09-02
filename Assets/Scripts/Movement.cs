using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumppower;
    [SerializeField] private float wallJumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool secondJump=true;
    private float jumpcd = 0;
    private float horizontalInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        if (jumpcd > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)))
            {
                if (isGrounded())
                {
                    Jump();
                    Invoke("doubleJump", 0.2f);
                }
                else if (onWall())
                {
                    wallJump();
                }
                else if (secondJump)
                {
                    Jump();
                    secondJump = false;
                }
            }
        }
        else jumpcd+=Time.deltaTime;
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumppower);
        anim.SetTrigger("jump");
    }
    private void wallJump()
    {
        body.velocity = new Vector2(-Math.Sign(transform.localScale.x)*6, 12);
        jumpcd = 0;
    }

     private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        if(raycastHit.collider != null)
            doubleJump();
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    private void doubleJump()
    {
        secondJump = true;
    }

    public bool canAttack()
    {
        if (!onWall())
            return true;
        else
            return false;
    }
}