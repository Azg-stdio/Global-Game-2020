using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    public GameObject camara;
    public GameObject eventmanager;
    Animator anim;
    int state = 0;
    void Start()
    {
        anim = ball.GetComponent<Animator>();
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
        anim.SetInteger("state", stateset);
        if (state == 0)
        {
            ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y+0.3f, ball.transform.position.z);
        }
        eventmanager.GetComponent<EventManager>().StartEvent(3.0f);
        if (stateset > 0)
        {
            ball.GetComponent<CapsuleCollider2D>().offset = new Vector2(0.008036428f, -0.3679461f);
            ball.GetComponent<CapsuleCollider2D>().size = new Vector2(1.640337f, 2.742879f);
            ball.GetComponent<CapsuleCollider2D>().direction = 0;
            ball.GetComponent<Movement>().enabled = false;
            ball.GetComponent<MovementLeg>().enabled = true;
        }
        state = stateset;
    }    
}
