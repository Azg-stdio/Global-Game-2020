﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject textmanager;
    [TextArea]
    public string text;
    public bool reset;
    public Transform resetpos;
    public bool repeat;
    bool onetime;
    public GameObject eventmager;
    public float quiettime = 0.0f;

    void Start()
    {
        onetime = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (onetime)
            {
                textmanager.GetComponent<SetText>().StartText(text);
                if (reset)
                {
                    col.transform.position = resetpos.position;
                }
                if (repeat)
                {
                    onetime = true;
                }
                else
                {
                    onetime = false;
                }
                if (quiettime > 0)
                {
                    eventmager.GetComponent<EventManager>().StartEvent(quiettime);
                }
            }
        }
    }
}