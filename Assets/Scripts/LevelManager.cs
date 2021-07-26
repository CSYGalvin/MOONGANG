using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
  public static LevelManager instance;

  public Transform respawnPoint;
  public GameObject playerPrefab;


  public Camera camera;
  private SmoothCameraFollow _camScript;


  private void Awake() {
    instance = this;
    _camScript = camera.GetComponent<SmoothCameraFollow>();
  }

  public void Respawn () {
    GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);     
    _camScript.target = player.transform;
    // player.SetActive(true);
    // player.transform.position = respawnPoint.position;
  }
}
