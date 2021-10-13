using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("player"))
        {
            DropPlatform();
            Destroy(gameObject, 2f);
        }
    }

    void DropPlatform()
    {
        rigidbody.isKinematic = false;
    }
}
