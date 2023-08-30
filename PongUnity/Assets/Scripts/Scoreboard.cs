using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public static Scoreboard Instance;

    private int p1Score,
               p2Score;
    public int maxScore;
    public string winMessage;
    public TextMeshProUGUI p1ScoreText,
                           p2ScoreText,
                           winMessageText;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        
    }

    void CheckWin()
    {
        if (p1Score >= maxScore)
        {
            winMessageText.text = "P2 " + winMessage;
        }
        else if (p2Score >= maxScore)
        {
            winMessageText.text = "P1 " + winMessage;
        }
        else
        {
            BallSpawner.Instance.SpawnBall();
        }
    }

    public void GiveToP1()
    {
        p1Score++;
        p1ScoreText.SetText(p1Score.ToString());
        CheckWin();
    }

    public void GiveToP2()
    {
        p2Score++;
        p2ScoreText.SetText(p2Score.ToString());
        CheckWin();
    }
}
