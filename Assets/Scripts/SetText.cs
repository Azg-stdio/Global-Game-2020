using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetText : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI frase;
    void Start()
    {
        
    }

    public void StartText(string text)
    {
        panel.SetActive(true);
        frase.text = "";
        StartCoroutine(WriteText(text));
    }

    IEnumerator WriteText(string oracion)
    {
        yield return new WaitForSeconds(1.0f);
        foreach (char letra in oracion)
        {
            frase.text = frase.text + letra;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2.0f);
        panel.SetActive(false);
    }
}
