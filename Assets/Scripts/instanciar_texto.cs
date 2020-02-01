using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciar_texto : MonoBehaviour
{
    public GameObject texto;

    void Start()
    {
        GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(texto,new Vector2(50,100),Quaternion.identity);
    }
}
