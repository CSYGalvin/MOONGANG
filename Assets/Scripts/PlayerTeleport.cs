using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject teleportBallPrefab;
    public Animator anim;
    public float y_speed;
    public float x_speed;
    
    private GameObject teleportBall;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Teleport")){
            if(teleportBall == null){
                int direction = gameObject.transform.localScale.x > 0 ? 1 : -1;
                Vector3 pos = new Vector3(gameObject.transform.position.x + direction, gameObject.transform.position.y + 1, gameObject.transform.position.z + 1);
                teleportBall = Instantiate(teleportBallPrefab, pos , Quaternion.identity);
                anim.SetTrigger("Throwing");
                teleportBall.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity + new Vector2(direction * x_speed, y_speed);

            }else{
                gameObject.transform.position = teleportBall.transform.position; 
                Destroy(teleportBall);
            }            
        } 
        if(Input.GetButtonDown("CancelTeleport")){
            if(teleportBall != null){
                Destroy(teleportBall);
            }
        }
    }
}
