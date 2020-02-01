using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public GameObject popin;
    bool interacting = false;
    public GameObject evolve;
    public KeyCode key;

    Animator anim;
    void Start()
    {
        anim = evolve.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (interacting && Input.GetKeyDown(key))
        {
            //anim.Play("FridgeDoor");
            Debug.Log("Cojo pierna");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            popin.GetComponent<SpriteRenderer>().enabled = true;
            interacting = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            popin.GetComponent<SpriteRenderer>().enabled = false;
            interacting = false;
        }
    }
}
