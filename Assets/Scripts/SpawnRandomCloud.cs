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

        while (flag)
        {
            Instantiate(clouds[Random.Range(0, 5)], new Vector3(-100.0f, 0.0f, 0.0f), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
