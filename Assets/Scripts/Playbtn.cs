using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playbtn : MonoBehaviour
{
    public void loadGame(){
        Debug.Log("clicked");
        SceneManager.LoadScene("Character Testing Scene");
    }
}
