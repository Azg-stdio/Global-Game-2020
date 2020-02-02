using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMusic : MonoBehaviour
{
    public AudioSource music;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            music.PlayDelayed(3.5f);
        }
    }
}
