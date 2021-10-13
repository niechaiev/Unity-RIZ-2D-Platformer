using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController2D controller;

    public float speed = 40f;
    float horizontalMove = 0f;
   public bool isJump = false;
    public Animator animator;

    void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {   
            
            isJump = true;
        }

        //if (Input.GetButton("Fire2") && isJump == false)
        //{
        //    animator.Play("Player_Attack", 0);
        //}
    }
    

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJump);
        isJump = false;
    }
}
