﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    bool isgrounded = true;
    public GameObject eventmanager;
    public GameObject splash;
    public GameObject sfxmanager;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity=new Vector3(0.0f, -9.0f, 0.0f);
    }

    bool direction;
    public float speed = 1;
    
    void FixedUpdate()
    {
        if (!eventmanager.GetComponent<EventManager>().playerisquiet)
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
                        rb.velocity = new Vector2(1.5f, 0.0f);
                        rb.freezeRotation = true;
                    }
                    direction = true;
                }
                else
                {
                    if (direction)
                    {
                        rb.velocity = new Vector2(1.5f, 0.0f);
                        rb.freezeRotation = true;
                    }
                    direction = false;
                }

                this.GetComponent<Rigidbody2D>().AddForce(movement * multiplier * speed * Time.deltaTime);
            }
        }
        else
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
        }     
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag=="Floor")
        {
            isgrounded = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Water")
        {
            rb.velocity = new Vector2(1.5f, rb.velocity.y);
            GameObject splashclone = Instantiate(splash, transform.position, Quaternion.identity);
            sfxmanager.GetComponent<MusicManager>().PlaySFX(2);
            Destroy(splashclone, 1.0f);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Water")
        {            
            //Physics.gravity = new Vector3(0.0f, -9.0f, 0.0f);
            //Physics2D.gravity = new Vector3(0.0f, -9.0f, 0.0f);
        }
    }
}
