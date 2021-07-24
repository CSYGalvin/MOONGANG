// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityStandardAssets._2D;

// public class PlatformDetector : MonoBehaviour
// {
//     public bool isGrounded;
//     public bool check;


//     void Update() {
//         isGrounded = PlatformerCharacter2D.m_Grounded;

//         if(isGrounded != true)
//         {
//             check = false;
//         }

//         if (check != true)
//         {
//             RaycastHit2D hit = physics2D.Raycast(transform.position, Vector2.down, .125f);

//             if (hit.collider.CompareTag("Platform"))
//             {
//                 player.SetParent(hit.transform);
//             }
//             else{
//                 player.SetParent(null);
//             }
//         }
//     }
// }
