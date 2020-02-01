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
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "prota")
        {
            Instantiate(texto, new Vector2(578, 469), Quaternion.identity);
            Destroy(texto,5f);
            Debug.Log("coloision");
        }

    }
}
