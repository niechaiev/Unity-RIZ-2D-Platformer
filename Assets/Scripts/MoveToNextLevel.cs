using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;

    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            SceneManager.LoadScene(nextSceneLoad);
    }
}
