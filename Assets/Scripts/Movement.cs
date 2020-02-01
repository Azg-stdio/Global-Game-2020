using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    bool isgrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    bool direction;
    public float speed = 1;
    
    void FixedUpdate()
    {        
        if (isgrounded)
        {
            int multiplier = 1;
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            rb.freezeRotation = false;
            if (moveHorizontal <= 0.0f)
            {
                if (!direction)
                {
                    rb.velocity = new Vector2(1.0f, 0.0f);
                    rb.freezeRotation = true;
                }
                direction = true;
            }
            else
            {
                if (direction)
                {
                    rb.velocity = new Vector2(1.0f, 0.0f);
                    rb.freezeRotation = true;
                }
                direction = false;
            }

            this.GetComponent<Rigidbody2D>().AddForce(movement * multiplier * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="Floor")
        {
            isgrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            isgrounded = false;
        }
    }
}
