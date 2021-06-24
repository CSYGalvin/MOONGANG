using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemytakedamage : MonoBehaviour
{
    public int health = 100;
    public Animator anim;
    public Collider2D col;

    private float deathDuration = 0.6f;
    private float deathTimeLeft = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //death countdown has started
        if (deathTimeLeft > 0) {
            deathTimeLeft = deathTimeLeft - Time.deltaTime;
            if (deathTimeLeft < 0.2f) {
                col.isTrigger = true;
            }
        }
        //death countdown has finished
        if (deathTimeLeft < 0) {
            anim.SetBool("isDying", false);
            Destroy(gameObject);
        }
    }

    void Die() {
        //play death animation and start death countdown
        anim.SetBool("isDying", true);        
        deathTimeLeft = deathDuration;
    } 
 
    void TakeDamage(int damageAmount)
    {
        health = health - damageAmount;
        anim.SetTrigger("TakeHit");

        // We should also check if the health is still greater than 0 
        // in order to determine whether enemy is still alive or not
        if (health < 0) {
            Die();
        }
    }
}