using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int intLoad;
    public string stringLoad;
    public bool useIntLoader = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      GameObject collisionGameObject = collision.gameObject;
      if (collisionGameObject.CompareTag("Player"))
      {
        LoadScene();
      }
    }

    void LoadScene()
    {
      if (useIntLoader)
      {
        SceneManager.LoadScene(intLoad);
      }
      else
      {
        SceneManager.LoadScene(stringLoad);
      }
    }
}
