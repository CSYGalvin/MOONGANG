using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody2D body;

    public Animator anim;

    public LayerMask groundLayers;
    
    public Transform feet;

    public AudioSource jumpSound;

    private float jumpForce = 20f;
    private float groundCheckRange = 0.6f;
    private float Speed = 10f;

    float mx;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
            playJump();
        }

        mx = Input.GetAxisRaw("Horizontal");
        // cannot run while attacking
        if(anim.GetBool("isAttacking") && isGrounded()){
            mx = 0;
        }
        // cannot move while dying or taking hit
        if(anim.GetBool("isDying") || anim.GetBool("isTakingHit")){
            mx = 0;
        }

        // flip player in the correct direction
        if (mx == 0f){
            // player did not move, don't need to flip
        }else if (mx < 0f){
            Vector3 direction = new Vector3(-1 * Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            transform.localScale = direction;
        }else {
            Vector3 direction = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            transform.localScale = direction;
        }

        // set animations
        anim.SetBool("isRunning", Mathf.Abs(mx) > 0.05f);
        anim.SetBool("isGrounded", isGrounded());
        anim.SetBool("isFalling", body.velocity.y < -0.01f);
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * Speed, body.velocity.y);
        body.velocity = movement;
    }

    void Jump()
    {
        Vector2 movement = new Vector2(body.velocity.x, jumpForce);
        body.velocity = movement;
    }

    public bool isGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, groundCheckRange, groundLayers);
        return groundCheck != null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feet.position, groundCheckRange);
    }

    private void playJump()
    {
        jumpSound.Play();
    }
}
