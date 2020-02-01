using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds;
    private float[] parallaxScales;

    public float smoothing;

    private Transform cam;
    private Vector3 previousCamPos;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main.transform;

        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {

            float parallax = cam.position.x - (cam.position.x / ((i + 1) * 8));
            Vector3 pos = new Vector3(parallax, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = pos;
        }
        previousCamPos = cam.position;
    }
}