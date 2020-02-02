using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    float increment = 0.05f;
    bool direction;
    public bool staticpos=false;
    void Start()
    {
        transform.localScale = new Vector3(Random.Range(0.4f,0.6f), Random.Range(0.4f, 0.6f),1.0f);
        if (Random.Range(1, 3) == 1)
        {
            if (!staticpos)
            {
                transform.position = new Vector3(-45.0f, Random.Range(0.0f, 7.0f), 1.0f);
            }
            direction = true;
        }
        else
        {
            if (!staticpos)
            {
                transform.position = new Vector3(30.0f, Random.Range(0.0f, 7.0f), 1.0f);
            }
            direction = false;
        }
        StartCoroutine(KillMePls());
    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
        {
            increment = 0.03f;
            transform.position = new Vector3(transform.position.x+increment, transform.position.y, transform.position.z);
        }
        else
        {
            increment = - 0.03f;
            transform.position = new Vector3(transform.position.x + increment, transform.position.y, transform.position.z);
        }
    }

    IEnumerator KillMePls()
    {
        yield return new WaitForSeconds(30.0f);
        Destroy(this.gameObject);
    }
}
