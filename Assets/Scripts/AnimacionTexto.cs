using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimacionTexto : MonoBehaviour
{
    public string oracion;
    public TextMeshPro frase;
    void Start()
    {
        StartCoroutine(retraso());
        oracion = frase.GetComponent<TextMeshPro>().text;
        
    }

    // Update is called once per frame
    IEnumerator retraso()
    {
        foreach (char letra in oracion)
        {
            frase.text = frase.text + letra;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
