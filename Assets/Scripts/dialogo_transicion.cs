using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogo_transicion : MonoBehaviour
{

    public string[] dialogo;
    public Text texto;
    public bool activar;
    Coroutine retraso;


    void Start()
    {

    }

    // Update is called once per frame
    void Conversacion()
    {
        if (activar)
        {
            TerminarDialogo();
            retraso = StartCoroutine(contar());
        }
    }

     IEnumerator contar()
    {
        string[] conversar;
        conversar = dialogo;
        int oracion = conversar.Length; 
        string reinicio = "";
        activar = true;
        yield return null;

        for (int i = 0; i < oracion; i++)
        {
            if (activar)
            {
                for (int s = 0; s < conversar[i].Length; s++)
                {
                    if (activar)
                    {
                        reinicio = string.Concat(reinicio, conversar[i][s]);
                        new WaitForSeconds(4);
                    }
                }
                TerminarDialogo();
            }
        }
     }
    public void TerminarDialogo()
    {
        activar = false;
        if(retraso != null)
        {
            StopCoroutine(retraso);
            retraso = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other)
        {
            Conversacion();
            TerminarDialogo();
        }
    }
}
