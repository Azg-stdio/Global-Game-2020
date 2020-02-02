using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public bool playerisquiet = false;

    public void StartEvent(float time)
    {
        playerisquiet = true;
        StartCoroutine(WaitForFinish(time));
    }

    IEnumerator WaitForFinish(float time)
    {
        yield return new WaitForSeconds(time);
        playerisquiet = false;
    }
}
