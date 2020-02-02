using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject[] objs;
    int objectselected = 0;
    public GameObject principal, credit, game, menu;
    bool credits = false;
    bool playing = false;
    void Start()
    {
        objectselected = 0;
        objs[0].GetComponent<Image>().color = new Color32(140, 140, 140, 255);
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (objectselected == 1)
                {
                    if (!credits)
                    {
                        credits = true;
                        principal.SetActive(false);
                        credit.SetActive(true);
                    }
                    else
                    {
                        credits = false;
                        principal.SetActive(true);
                        credit.SetActive(false);
                    }

                }
                if (objectselected == 2)
                {
                    Application.Quit();
                }
                if (objectselected == 0)
                {
                    game.SetActive(true);
                    menu.SetActive(false);
                    playing = true;
                }
            }
            if (!credits)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    if (objectselected == 2)
                    {
                        ChangeObject(0);
                    }
                    else if (objectselected == 1)
                    {
                        ChangeObject(2);
                    }
                    else
                    {
                        ChangeObject(1);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    if (objectselected == 0)
                    {
                        ChangeObject(2);
                    }
                    else if (objectselected == 1)
                    {
                        ChangeObject(0);
                    }
                    else
                    {
                        ChangeObject(1);
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (playing)
            {
                menu.SetActive(true);
                game.SetActive(false);
                playing = false;
            }
        }
    }

    void ChangeObject(int obj)
    {
        objs[objectselected].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        objs[obj].GetComponent<Image>().color = new Color32(140,140,140,255);
        objectselected = obj;
    }
}
