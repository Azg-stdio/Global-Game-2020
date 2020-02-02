using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform ball;
    public GameObject statemanager;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (statemanager.GetComponent<StateManager>().GetState() == 0)
        {
            transform.position = new Vector3(ball.position.x, ball.position.y + 3.0f, -5.0f);
        }
        else if (statemanager.GetComponent<StateManager>().GetState() == 1)
        {
            transform.position = new Vector3(ball.position.x, ball.position.y +1.95f, -5.0f);
        }
    }
}
