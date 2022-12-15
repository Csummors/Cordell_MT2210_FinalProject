using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask ground;
    
    public float speed;
    public float jumpSpeed = 1;
   
    private Rigidbody2D rb;
    private SpriteRenderer sb;
    
    bool jumping;
    float xMove;

    private int jumpCount;
    public int jumpCountMax = 2;

    public float distanceCheckAmount = 0.5f;

    public GameManager gm;
    public AudioClip jumpClip;

    // Start is called before the first frame update
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        sb = GetComponent<SpriteRenderer>();
      
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Are we on the ground - " + GroundCheck());


        xMove = Input.GetAxis("Horizontal");

        if (xMove != 0) 
        {
            if (xMove > 0)
            {
                sb.flipX = true;
            }
            else 
            {
                sb.flipX = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < jumpCountMax)
        {
            jumping = true;
            gm.PlaySound(jumpClip);
            jumpCount++;

            
        }

        if (GroundCheck()) 
        {
            jumpCount = 1;
        }
    }

    private void FixedUpdate()
    {

       

        rb.velocity = new Vector2(xMove * speed * Time.deltaTime, rb.velocity.y);

        if (jumping == true)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            //rb.AddForce(Vector2.up * jumpSpeed * Time.deltaTime,ForceMode2D.Impulse);
            jumping = false;
        }

    }


    public bool GroundCheck() 
    {
        return Physics2D.Raycast(transform.position,Vector2.down, distanceCheckAmount, ground);
    }
   
}
