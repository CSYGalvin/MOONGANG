using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator anim;

    public Transform Attackpoint;

    public LayerMask player;
    
    private float hitRange = 0.5F;    
    private int AttackDamage = 30;

    private float attackDuration = 2f;
    private float attackTimeLeft = 0;
    private bool damageDealt = false;

    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //countdown timer since last Attack Animation
        if(attackTimeLeft > 0) {
            attackTimeLeft = attackTimeLeft - Time.deltaTime;

            if(!damageDealt && attackTimeLeft < 1.5f){
                Collider2D playerCol = Physics2D.OverlapCircle(Attackpoint.position, hitRange, player);
                if (playerCol != null) {
                    playerCol.gameObject.SendMessage("TakeDamage", AttackDamage);
                }
                damageDealt = true;
                anim.SetBool("isAttacking", false);
            }
        } else {
            if (Physics2D.OverlapCircle(Attackpoint.position, hitRange, player) != null) {
                Attack();
            }
        }
    }

    private void Attack() {
        //play attack animation
        anim.SetBool("isAttacking", true);
        //start Attack Countdown
        attackTimeLeft = attackDuration;
        damageDealt = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attackpoint.position, hitRange);
    }
}
