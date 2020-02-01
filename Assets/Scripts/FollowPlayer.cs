using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform state0, state1, state2;
    Transform actualstate;
    void Start()
    {
        actualstate = state0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(actualstate.position.x, actualstate.position.y, -5.0f);
    }

    public void SetFollower(int state)
    {
        switch (state)
        {
            case 0:
                actualstate = state0;
                break;
            case 1:
                actualstate = state1;
                break;
            case 2:
                actualstate = state2;
                break;
            default:
                Debug.Log("Weird");
                break;
        }
    }
}
