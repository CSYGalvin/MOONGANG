using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float AdjTime;
    public Rigidbody2D body;
    public Animator anim;
    public bool isAttacking = false;
    public bool isDying = false;
    public bool isTakingHit = false;

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
        if(isAttacking || isDying || isTakingHit){
            body.velocity = new Vector2(0, body.velocity.y);
            return;
        }
        if (AdjTime == 0f) {
            return;
        }

        if (anim.GetBool("isDying")){
            mx = 0;
        }
        
        if (MovingTime > 0) {           
            Vector2 movement = new Vector2(mx * Speed, body.velocity.y);
            body.velocity = movement;
            MovingTime -= Time.deltaTime;                         
        } else {
            MovingTime = AdjTime;
            mx = -mx;
            transform.localScale = new Vector3(-transform.localScale.x,5,1);
        }      

    }

}
