using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    public Paddle paddle;
    Ball currentBall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindBall();
    }

    void TrashTalk()
    {
        Debug.Log("EZ FF");
    }

    void FindBall()
    {
        if (currentBall == null)
        {
            currentBall = FindObjectOfType<Ball>();
        }
    }

    void FollowBall()
    {
        if (currentBall.transform.position.y )
    }
}
