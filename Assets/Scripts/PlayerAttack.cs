using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;

    private float attackDuration;
    private float attackTimeLeft = 0;

    public float hitRange = 1.25F;
    public Transform Attackpoint;
    public int AttackDamage;

    public LayerMask enemies;

    // Start is called before the first frame update
    void Start()
    {
        hitRange = 1.25F;
        attackDuration = 0.33F;
        AttackDamage = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //countdown timer since last attacked
        if(attackTimeLeft > 0) {
            attackTimeLeft = attackTimeLeft - Time.deltaTime;
        } else {
            anim.SetBool("isAttacking", false);
        }

        if (Input.GetButtonDown("Fire1")) {
            if (attackTimeLeft <= 0) {
                attackTimeLeft = attackDuration;
                Attack();
            }
        }
    }

    private void Attack() {
        //play attack animation
        anim.SetBool("isAttacking", true);

        //check for enemies in range
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(Attackpoint.position, hitRange, enemies);

        //deal damage to enemies
        foreach(Collider2D enemy in enemiesInRange) {
            enemy.gameObject.SendMessage("TakeDamage", AttackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attackpoint.position, hitRange);
    }
}
