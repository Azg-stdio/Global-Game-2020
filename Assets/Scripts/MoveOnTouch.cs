using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{
    public AnimationCurve curve;
    public Vector3 distance = new Vector3(0.8f, 0.5f,0.0f);
    public float speed=0.12f;

    bool jiggling;

    private Vector3 startPos, toPos;
    private float timeStart;

    void randomToPos()
    {
        toPos = startPos;
        toPos.x += Random.Range(-1.0f, +1.0f) * distance.x;
        toPos.y += Random.Range(-1.0f, +1.0f) * distance.y;
        toPos.z += Random.Range(-1.0f, +1.0f) * distance.z;
        timeStart = Time.time;
    }

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        randomToPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (jiggling)
        {
            float d = (Time.time - timeStart) / speed, m = curve.Evaluate(d);
            if (d > 1)
            {
                randomToPos();
            }
            else if (d < 0.5)
            {
                transform.position = Vector3.Lerp(startPos, toPos, m * 2.0f);
            }
            else
            {
                transform.position = Vector3.Lerp(toPos, startPos, (m - 0.5f) * 2.0f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            jiggling = true;
            StartCoroutine(StopJiggling());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jiggling = false;
        }
    }

    IEnumerator StopJiggling()
    {
        yield return new WaitForSeconds(0.4f);
        jiggling = false;
    }
}
