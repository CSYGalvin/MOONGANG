using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScreen : MonoBehaviour
{
    public GameObject controlPanel;
    public GameObject homePanel;

    public void loadGame(){
        Debug.Log("clicked");
        SceneManager.LoadScene("Dungeon");
    }
    public void enableControlPanel(){
        homePanel.SetActive(false);
        controlPanel.SetActive(true);
    }
    public void disableControlPanel(){
        homePanel.SetActive(true);
        controlPanel.SetActive(false);
    }
}
