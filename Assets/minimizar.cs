using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimizar : MonoBehaviour
{
    Animator puntero;
    public GameObject guide;
    void Start()
    {
        StartCoroutine(Minimizar());
        puntero = GetComponent<Animator>();
        guide.GetComponent<AnimacionTexto>().Puente();
    }

    IEnumerator Minimizar()
    {
        
            yield return new WaitForSeconds(8.0f);
            puntero.SetBool("cierre",true);
    }
}
