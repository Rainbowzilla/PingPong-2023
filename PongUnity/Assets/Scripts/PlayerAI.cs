using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    public Paddle paddle;
    Ball currentBall;
    public float distanceBuffer;
    public bool overridePlayer;

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
        if (overridePlayer == true)
        {
            if (currentBall == null)
            {
                currentBall = FindObjectOfType<Ball>();
            }
        }
        FollowBall();
    }

    void FollowBall()
    {
        if (currentBall.transform.position.y + distanceBuffer > paddle.transform.position.y && transform.position.y < paddle.maxYposition)
        {
            paddle.MoveUp();
        }
        if (currentBall.transform.position.y - distanceBuffer < paddle.transform.position.y && transform.position.y > -paddle.maxYposition)
        {
            paddle.MoveDown();
        }
    }
}
