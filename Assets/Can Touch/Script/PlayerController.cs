using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed = 1;
    private Rigidbody2D rb;
    private SpriteRenderer sb;
    bool jumping;
    float xMove;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GetSum(6,138)); 
        rb = GetComponent<Rigidbody2D>();
        sb = GetComponent<SpriteRenderer>();
      
    }

    // Update is called once per frame
    void Update()
    {

        //float n = Util.RemapRange(transform.position.x, -8, 8, 0, 1);
       // music.volume = n;

        //float x = FollowPlayer.Test();
        
        //sr.color = colorGradient.Evluate(n);

        //#Method 1 - the Transation Method

        xMove = Input.GetAxis("Horizontal");
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

        /*
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
        */

        rb.velocity = new Vector2(xMove * speed * Time.deltaTime, rb.velocity.y);

        if (jumping == true)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            //rb.AddForce(Vector2.up * jumpSpeed * Time.deltaTime,ForceMode2D.Impulse);
            jumping = false;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public float GetSum(float a, float b) 
    {
        return a +b;
    }

}
