using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimacionTexto : MonoBehaviour
{    
    public TextMeshPro frase;
    public string oracion;

    void Start()
    {
        StartCoroutine(Pausa());
    }
    IEnumerator Pausa()
    {
        yield return new WaitForSeconds(5.0f);
        StartCoroutine(Retraso());
    }

    public void Puente()
    {
        StartCoroutine(Retraso());
    }
    IEnumerator Retraso()
    {
        Debug.Log("Retraso");
        Debug.Log(oracion);
        foreach (char letra in oracion)
        {
            Debug.Log("Si");
            frase.text = frase.text + letra;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
