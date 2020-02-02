using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject textmanager;
    [TextArea]
    public string text;
    public bool reset;
    public float resettime = 0.0f;
    public Transform resetpos;
    public bool repeat;
    bool onetime;
    public GameObject eventmager;
    public float quiettime = 0.0f;
    public float wait=0.0f;

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
                if (repeat)
                {
                    onetime = true;
                }
                else
                {
                    onetime = false;
                }
                StartCoroutine(WaitCertainTime(wait, col));                
            }
        }
    }

    IEnumerator WaitCertainTime(float wait, Collider2D col)
    {
        yield return new WaitForSeconds(wait);
        textmanager.GetComponent<SetText>().StartText(text);
        if (reset)
        {
            yield return new WaitForSeconds(resettime);
            col.transform.position = resetpos.position;
        }
        if (quiettime > 0)
        {
            eventmager.GetComponent<EventManager>().StartEvent(quiettime);
        }
    }
}
