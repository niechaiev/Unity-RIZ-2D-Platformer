using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GFX : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath aIPath;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(aIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        else if (aIPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
