using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetText : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI frase;
    public GameObject sound;
    void Start()
    {
        
    }

    public void StartText(string text)
    {
        panel.SetActive(true);
        frase.text = "";
        StartCoroutine(WriteText(text));
        sound.GetComponent<MusicManager>().PlaySFX(1);
    }

    IEnumerator WriteText(string oracion)
    {
        yield return new WaitForSeconds(1.0f);
        sound.GetComponent<MusicManager>().PlaySFX(0);
        foreach (char letra in oracion)
        {
            frase.text = frase.text + letra;
            yield return new WaitForSeconds(0.05f);
        }
        sound.GetComponent<MusicManager>().StopSFX();
        yield return new WaitForSeconds(2.0f);
        panel.SetActive(false);
    }
}
