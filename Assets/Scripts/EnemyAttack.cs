using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator anim;

    public Transform Attackpoint;

    public LayerMask player;

    public EnemyMovement enemyMovement;
    
    private float hitRange = 0.5F;    
    private int AttackDamage = 30;

    private bool onCooldown = false;


    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!onCooldown){
            if (Physics2D.OverlapCircle(Attackpoint.position, hitRange, player) != null) {
                Attack();
            }
        }
    }

    private void Attack() {
        StartCoroutine(AttackAnimCoroutine());
        StartCoroutine(DealDamageCoroutine());
        StartCoroutine(StartAttackCoolDown());
    }

    private IEnumerator AttackAnimCoroutine(){
        anim.SetTrigger("Attack");
        enemyMovement.isAttacking= true;
        yield return new WaitForSeconds(0.67f);        
        enemyMovement.isAttacking = false;
    }

    private IEnumerator DealDamageCoroutine(){
        yield return new WaitForSeconds(0.5f);  
        if(!enemyMovement.isDying && !enemyMovement.isTakingHit){
            Collider2D playerCol = Physics2D.OverlapCircle(Attackpoint.position, hitRange, player);
            if (playerCol != null) {
                playerCol.gameObject.SendMessage("TakeDamage", AttackDamage);
            }
        }
    }

    private IEnumerator StartAttackCoolDown(){
        onCooldown = true;
        yield return new WaitForSeconds(2f); 
        onCooldown = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attackpoint.position, hitRange);
    }
}
