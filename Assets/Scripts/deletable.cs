using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
