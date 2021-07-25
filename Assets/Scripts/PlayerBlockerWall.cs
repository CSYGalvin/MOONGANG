using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockerWall : MonoBehaviour
{
    void Start(){}
    void OnCollisionEnter2D(Collision2D collider) 
    {
        if(collider.gameObject.CompareTag("Ball")){
            Physics2D.IgnoreCollision( collider.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    void OnCollisionExit2D(Collision2D collider) {
    }
    // void OnTriggerExit2D(Collision2D collider) {
    //     if (collider.gameObject.CompareTag("Player")) {
    //         collider.collider.enabled = true;
    //     }
    // }

}