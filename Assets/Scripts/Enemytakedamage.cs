using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemytakedamage : MonoBehaviour
{
    public int health = 100;
    public Animator anim;
    public Collider2D col;

    public EnemyMovement enemyMovement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void Die() {
        //play death animation and start death countdown
        StartCoroutine(DeathAnimCoroutine());     

    } 
 
    private IEnumerator DeathAnimCoroutine(){
        anim.SetTrigger("Death");
        enemyMovement.isDying = true;
        yield return new WaitForSeconds(0.5f);   
        Destroy(gameObject);
    }

    void TakeDamage(int damageAmount)
    {
        health = health - damageAmount;
        StartCoroutine(TakeHitAnimCoroutine());

        // We should also check if the health is still greater than 0 
        // in order to determine whether enemy is still alive or not
        if (health < 0) {
            Die();
        }
    }
    private IEnumerator TakeHitAnimCoroutine(){
        anim.SetTrigger("TakeHit");
        enemyMovement.isTakingHit = true;
        yield return new WaitForSeconds(0.4f);   
        enemyMovement.isTakingHit = false;
    }
}