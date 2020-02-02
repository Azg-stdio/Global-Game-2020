using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLeg : MonoBehaviour
{
    Rigidbody2D rb;
    bool isgrounded = true;
    Animator anim;
    Vector3 reset = new Vector3(0.0f, 0.0f, 0.0f);
    public bool legfixed = false;
    public GameObject eventmanager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    bool direction;
    public float speed = 1;
    
    void FixedUpdate()
    {
        if (!eventmanager.GetComponent<EventManager>().playerisquiet)
        {
            if (legfixed)
            {
                transform.localEulerAngles = reset;
            }

            if (isgrounded)
            {
                int multiplier = 1;
                float moveHorizontal = Input.GetAxis("Horizontal");
                Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
                rb.freezeRotation = false;
                if (moveHorizontal < 0.0f)
                {
                    Vector3 aux = new Vector3(-0.9f, 0.9f, 1.0f);
                    this.gameObject.transform.localScale = aux;
                    if (!direction)
                    {
                        rb.velocity = new Vector2(1.0f, 0.0f);
                        rb.freezeRotation = true;
                    }
                    direction = true;
                    anim.SetBool("iswalking", true);
                }
                else if (moveHorizontal > 0.0f)
                {
                    Vector3 aux = new Vector3(0.9f, 0.9f, 1.0f);
                    this.gameObject.transform.localScale = aux;
                    if (direction)
                    {
                        rb.velocity = new Vector2(1.0f, 0.0f);
                        rb.freezeRotation = true;
                    }
                    direction = false;
                    anim.SetBool("iswalking", true);
                }
                else
                {
                    rb.velocity = new Vector2(0.0f, 0.0f);
                    rb.freezeRotation = true;
                    anim.SetBool("iswalking", false);
                }

                this.GetComponent<Rigidbody2D>().AddForce(movement * multiplier * speed * Time.deltaTime);
            }
        }
        else
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
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
