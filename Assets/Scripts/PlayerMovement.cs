using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D body;

    public Animator anim;

    public float jumpForce;
    public Transform feet;
    public LayerMask groundLayers;
    public SpriteRenderer sprite;

    float mx;
    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 20f;
        Speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }

        mx = Input.GetAxisRaw("Horizontal");
        // cannot run while attacking
        if(anim.GetBool("isAttacking") && isGrounded()){
            mx = 0;
        }
        // flip player in the correct direction
        if (mx == 0f){
            // player did not move, don't need to flip
        }else if (mx < 0f){
            transform.localScale = new Vector3(-5,5,1);
        }else {
            transform.localScale = new Vector3(5,5,1);
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
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.05f, groundLayers);

        return groundCheck != null;
    }
}
