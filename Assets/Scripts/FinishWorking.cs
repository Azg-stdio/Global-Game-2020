using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishWorking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(6.5f);
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(FinishGame());
        }
    }
}
