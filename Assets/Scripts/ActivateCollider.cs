using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCollider : MonoBehaviour
{
    public GameObject boxcollider;
    public bool activate;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (activate)
            {
                boxcollider.GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                boxcollider.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
