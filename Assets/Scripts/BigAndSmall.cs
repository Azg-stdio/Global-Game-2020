using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAndSmall : MonoBehaviour
{
    Vector3 initialscale;
    float scalecount=0.0f;
    bool direction = true;
    public float maxthreshold=0.1f;
    public float minthreshold=-0.1f;
    void Start()
    {
        initialscale = transform.localScale;
    }

    void Update()
    {
        if (scalecount >= maxthreshold)
        {
            direction = true;
        }
        if (scalecount <= minthreshold)
        {
            direction = false;
        }
        if (direction)
        {
            transform.localScale = new Vector3(transform.localScale.x+0.001f,transform.localScale.y+0.001f,1.0f);
            scalecount=scalecount-0.05f;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.001f, transform.localScale.y - 0.001f, 1.0f);
            scalecount=scalecount+0.05f;
        }        
    }
}
