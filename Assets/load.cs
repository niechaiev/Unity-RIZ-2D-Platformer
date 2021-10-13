using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Load", 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Load()
    {
        SceneManager.LoadScene(0);
    }
}
