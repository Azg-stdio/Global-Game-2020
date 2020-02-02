using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public GameObject popin;
    bool interacting = false;
    public KeyCode key;
    public GameObject statemanager;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (interacting && Input.GetKeyDown(key))
        {
            statemanager.GetComponent<StateManager>().SetState(1);
            this.gameObject.SetActive(false);
            popin.SetActive(false);
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
