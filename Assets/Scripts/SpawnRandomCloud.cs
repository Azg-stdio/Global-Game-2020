using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomCloud : MonoBehaviour
{
    public GameObject[] clouds;
    void Start()
    {
        StartCoroutine(Spawner());
        Instantiate(clouds[Random.Range(0, 5)], new Vector3(-100.0f, 0.0f, 0.0f), Quaternion.identity);
    }

    public IEnumerator Spawner()
    {
        bool flag = true;
        int randomst;
        while (flag)
        {
            randomst = Random.Range(0, 5);
            Instantiate(clouds[randomst], new Vector3(-100.0f, 0.0f, 0.0f), Quaternion.identity);
            yield return new WaitForSeconds(8.0f);
        }
    }
}
