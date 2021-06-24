using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    
    public LayerMask enemies;

    public Transform Attackpoint;

    private float attackDuration = 0.333f;
    private float attackTimeLeft = 0;
    private bool damageDealt = false;    
    
    private int AttackDamage = 60;
    private float hitRange = 1.25F;    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown timer since last attacked
        if(attackTimeLeft > 0) {
            attackTimeLeft = attackTimeLeft - Time.deltaTime;
            // During middle of attack animation, deal damage to enemies in range
            if (attackTimeLeft < 0.2f && !damageDealt){
                Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(Attackpoint.position, hitRange, enemies);
                foreach(Collider2D enemy in enemiesInRange) {
                    enemy.gameObject.SendMessage("TakeDamage", AttackDamage);
                }
                damageDealt = true;
            }
        } else {
            anim.SetBool("isAttacking", false);
        }

        // Player is attacking
        if (Input.GetButtonDown("Fire1")) {
            if (attackTimeLeft <= 0) {         
                Attack();
            }
        }
    }

    private void Attack() {
        // Play attack animation
        anim.SetBool("isAttacking", true);
        attackTimeLeft = attackDuration;
        damageDealt = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attackpoint.position, hitRange);
    }
}
