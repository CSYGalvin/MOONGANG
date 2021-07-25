using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject teleportBallPrefab;
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
                Vector3 pos = new Vector3(gameObject.transform.position.x + gameObject.transform.localScale.x/5, gameObject.transform.position.y + 1, gameObject.transform.position.z);
                teleportBall = Instantiate(teleportBallPrefab, pos , Quaternion.identity);
                teleportBall.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.transform.localScale.x * 3, 10);
            }else{
                gameObject.transform.position = teleportBall.transform.position; 
                Destroy(teleportBall);
            }

            
        } 
    }
}
