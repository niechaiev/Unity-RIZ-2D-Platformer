using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Animator animator;

    public Transform attackPos;
    public float xVal;
    public float yVal;
    public LayerMask whatIsEnemy;
    public float angle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            //can attack
            if (Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.RightAlt))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(xVal, yVal), angle, whatIsEnemy);
                if (enemiesToDamage.Length > 0)
                {
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<Collide>().health.Damage(damage);
                    }
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(xVal, yVal, 1));
    }
}
