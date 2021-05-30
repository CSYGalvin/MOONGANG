using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D body;

    public Animator anim;

    public float jumpForce = 10f;
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
        mx = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }
        if (mx >= 0f)
        {
          sprite.flipX = false;
        }
        else
        {
          sprite.flipX = true;
        }

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
