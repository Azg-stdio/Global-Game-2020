using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public bool playerisquiet = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartEvent()
    {
        playerisquiet = true;
        StartCoroutine(WaitForFinish());
    }

    IEnumerator WaitForFinish()
    {
        yield return new WaitForSeconds(3.0f);
        playerisquiet = false;
    }
}
