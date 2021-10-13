using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask LayerMask;
    public Animator animator;
    public float speed = 20f;
    public float jump = 10;
    private bool isGround = true;


    private Rigidbody2D rb;
    private bool facingRight = true;

    public CapsuleCollider2D boxCollider2D;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(moveX));


        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            animator.SetBool("Jumping", true);
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
        else if (!IsGrounded())
        {
            animator.SetBool("Jumping", false);
        }

        Flip(moveX);

    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0  && !facingRight || horizontal < 0 && facingRight){
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.CapsuleCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, CapsuleDirection2D.Vertical,
            0f, Vector2.down, .1f, LayerMask);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }
}
