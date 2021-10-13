using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpace : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject respawn;
    public GameHandler GameHandler;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.position = respawn.transform.position;
            GameHandler.healthSystem.Damage(10);
        }
    }
}
