using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCollide : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage;
    private bool isInstant;

    public int Damage { get => damage; set => damage = value; }
    public bool IsInstant { get => isInstant; set => isInstant = value; }

    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Collide>().health.Damage(Damage);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (IsInstant) return;
        
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Collide>().health.Damage(Damage);
        }
    }
}
