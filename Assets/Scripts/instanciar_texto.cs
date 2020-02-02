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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "prota")
        {
            GameObject clone = Instantiate(texto, new Vector2(578, 469), Quaternion.identity);
            Destroy(clone, 15.0f);
        }
        
    }
}
