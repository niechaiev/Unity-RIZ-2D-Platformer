using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collide : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath aIPath;
    public GameHandler GameHandler;
    public HealthSystem health;
    public int maxHealth = 20;
    Image redBar;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //collision.attachedRigidbody.AddForce((collision.transform.position - aIPath.transform.position) * 5, ForceMode2D.Impulse);
            var push = collision.transform.position - aIPath.transform.position;
            if (push.x < 0) push.x = -1;
            else if (push.x > 0) push.x = 1;
            if (push.y < 0) push.y = -1;
            else if (push.y > 0) push.y = 1;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(push.x * 1250f, push.y * 125f));
            GameHandler.healthSystem.Damage(5);
            health.Damage(1);
          
        }


    }

    private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
    {
        redBar.transform.localScale = new Vector3((float)health.GetHealth() / maxHealth, 1.0f, 1.0f);
        if (health.GetHealth() <= 0) gameObject.SetActive(false);
    }
    
    void Start()
    {
        health = new HealthSystem(maxHealth);
        health.OnHealthChanged += HealthSystem_OnHealthChanged;

        redBar = transform.Find("HealthCanvas").Find("Background").Find("Fill").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(aIPath.steeringTarget);
    }
}
