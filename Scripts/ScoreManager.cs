using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using unityroom.Api;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Ranking ranking;
    [SerializeField] Text scoreText;
    [SerializeField] Text resultText;

    private int score = 0;

    public void PlusScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void MinusScore()
    {
        if(score > 0)
        {
            score--;
        }

        scoreText.text = score.ToString();
    }

    public void DecideRanking()
    {
        ranking.SetRanking(score);
        ranking.GetRanking();

        resultText.text = score.ToString();
        UnityroomApiClient.Instance.SendScore(1, score, ScoreboardWriteMode.HighScoreDesc);
    }
}
