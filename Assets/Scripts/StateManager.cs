using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject state0, state1, state2;
    public GameObject camara;
    int state = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetState()
    {
        return state;
    }

    public void SetState(int stateset)
    {
        Vector3 pos = new Vector3(0.0f,0.0f,0.0f);
        GameObject newstate=state0;
        switch (state)
        {
            case 0:
                pos = state0.transform.position;               
                break;
            case 1:
                pos = state1.transform.position;
                break;
            case 2:
                pos = state2.transform.position;
                break;
            default:
                Debug.Log("Weird");
                break;
        }
        switch (stateset)
        {
            case 0:
                newstate = state0;
                break;
            case 1:
                newstate = state1;
                break;
            case 2:
                newstate = state2;
                break;
            default:
                Debug.Log("Weird");
                break;
        }
        ChangeState(newstate, pos);
        camara.GetComponent<FollowPlayer>().SetFollower(stateset);
    }

    void ChangeState(GameObject statechange, Vector3 position)
    {
        state0.SetActive(false);
        state1.SetActive(false);
        state2.SetActive(false);
        statechange.SetActive(true);
        statechange.transform.position = position;
    }
}
