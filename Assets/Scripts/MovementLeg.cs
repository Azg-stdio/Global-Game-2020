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

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;
    public float jumpVelocity = 5.0f;

    public AudioSource steps;

    public float maxVelocity = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GetComponent<CircleCollider2D>().enabled = true;
    }

    bool direction;
    public float speed = 1;
    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isgrounded)
            {
                rb.velocity = Vector2.up * jumpVelocity;
            }
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        if (!eventmanager.GetComponent<EventManager>().playerisquiet)
        {
            if (legfixed)
            {
                transform.localEulerAngles = reset;
            }
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
                        rb.velocity = new Vector2(1.0f, rb.velocity.y);
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
                        rb.velocity = new Vector2(1.0f, rb.velocity.y);
                        rb.freezeRotation = true;
                    }
                    direction = false;
                    anim.SetBool("iswalking", true);
                if (!steps.isPlaying)
                {
                    steps.Play();
                }
                }
                else
                {
                    rb.velocity = new Vector2(0.0f, rb.velocity.y);
                    rb.freezeRotation = true;
                    anim.SetBool("iswalking", false);
                steps.Stop();
                }

                this.GetComponent<Rigidbody2D>().AddForce(movement * multiplier * speed * Time.deltaTime);
            
        }
        else
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
        }        
        if (rb.velocity.x > maxVelocity)
        {
            rb.velocity = new Vector2(maxVelocity, rb.velocity.y);
        }
        if (rb.velocity.x < (0-maxVelocity))
        {
            rb.velocity = new Vector2(-maxVelocity, rb.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Floor"))
        {
            isgrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.CompareTag("Floor"))
        {
            isgrounded = false;
        }
    }
}
