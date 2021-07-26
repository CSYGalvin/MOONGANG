using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertakedamage : MonoBehaviour
{
  public int health = 100;
  public Animator anim;
  public Collider2D col;
  public HealthBar healthbar;

  private float deathDuration = 0.6f;
  private float deathTimeLeft = 0;

  private float takeHitDuration = 0.333f;
  private float takeHitTimeLeft = 0;

  void Start(){
    healthbar.setMaxHealth(health);
  }

  void Update()
  {
    // TakeHit countdown has started
    if (takeHitTimeLeft > 0) {
      // Knockback from taking hit
      transform.Translate(new Vector3(-transform.localScale.x * takeHitTimeLeft * 0.02f, 0, 0));
      takeHitTimeLeft = takeHitTimeLeft - Time.deltaTime;
    }

    // TakeHit countdown has finished
    if (takeHitTimeLeft < 0) {      
      anim.SetBool("isTakingHit", false);

      if (health < 0 && deathTimeLeft == 0) {
        Die();
      }
    }

    // Death countdown has started
    if (deathTimeLeft > 0) {
        deathTimeLeft = deathTimeLeft - Time.deltaTime;
    }
    
    // Death countdown has finished
    if (deathTimeLeft < 0) {
        anim.SetBool("isDying", false);
        gameObject.SetActive(false);
        LevelManager.instance.Respawn();
    }
  }

  // Start Death animation and Death countdown
  void Die() {
    anim.SetBool("isDying", true);  
    deathTimeLeft = deathDuration;
  }

  // Deal damage, start TakeHit animation and start TakeHit countdown
  void TakeDamage(int damageAmount) {
    anim.SetBool("isTakingHit", true);
    health = health - damageAmount;
    takeHitTimeLeft = takeHitDuration;
    healthbar.setHealth(health);    
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.CompareTag("InstantDeath")){
      TakeDamage(1000);
    } else if (collision.gameObject.CompareTag("Enemy")) {
      // LevelManager.instance.Respawn();
      // Destroy(gameObject);
      TakeDamage(50);
    }
  }

}
