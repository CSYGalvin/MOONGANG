using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float AdjTime;
    public Rigidbody2D body;
    public Animator anim;

    private float MovingTime;
    private float Speed = 4f;
    private float mx = 1;
    // Start is called before the first frame update
    void Start()
    {
        MovingTime = AdjTime;
        anim.SetBool("isRunning", AdjTime != 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (AdjTime == 0f) {
            return;
        }

        if (anim.GetBool("isDying")){
            mx = 0;
        }
        
        if (MovingTime > 0) {
            if (anim.GetBool("isAttacking")) {
                body.velocity = new Vector2(0,0);
            } else {                
                Vector2 movement = new Vector2(mx * Speed, body.velocity.y);
                body.velocity = movement;
                MovingTime -= Time.deltaTime; 
            }            
        } else {
            MovingTime = AdjTime;
            mx = -mx;
            transform.localScale = new Vector3(-transform.localScale.x,5,1);
        }      

    }
}
