using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed = 1;
    private Rigidbody2D rb;

    bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //#Method 1 - the Transation Method

        //float xMove = Input.GetAxis("Horizontal");
        //transform.Translate(xMove * speed * Time.deltaTime, 0, 0);

        /*
        //hold
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }


        //tap
        //delta not need because it only on one frame and one fram
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            transform.Translate(0, jumpSpeed, 0);
        }
        */

        //#Method 2 - The Velocity Method
        //#Method 2 is the preferred Method
        //#Method 3 - The Force Method
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }


    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            //rb.AddForce(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            //rb.AddForce(Vector2.right * speed * Time.deltaTime);

        }

        if (jumping == true)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            //rb.AddForce(Vector2.up * jumpSpeed * Time.deltaTime,ForceMode2D.Impulse);
            jumping = false;
        }
      
    }
}
