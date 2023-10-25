using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public Transform player;
    public float speed = 10.0f;
    public Animator animator;
    float move;
    public bool onGround = false;
    public float jumpForce = 10.0f;
    bool m_FacingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(move));
        player.position += new Vector3(move, 0, 0);
        if (Input.GetKeyDown("space") && onGround)
        {
            //isJumping = true;
            //rb.velocity = new Vector3(0, 1, 0) * jumpForce;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Debug.Log("Player flipped");
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Debug.Log("Player flipped");
            Flip();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
        onGround = true;
        }
        animator.SetBool("isJumping", !onGround);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
        animator.SetBool("isJumping", !onGround);
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
