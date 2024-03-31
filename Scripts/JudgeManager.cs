using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JudgeManager : MonoBehaviour
{
    [SerializeField] MusicManager musicManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Enemy enemy;

    [SerializeField] GameObject correctImage;
    [SerializeField] GameObject incorrectImage;

    private float displayTime = 0;
    private bool displayImage = false;

    void Update()
    {
        // マルかバツの画像が表示されているとき
        if(displayImage)
        {
            displayTime += Time.deltaTime;

            if (displayTime >= 0.5f)  // 一定時間経過で画像を消す
            {
                correctImage.SetActive(false);
                incorrectImage.SetActive(false);
                enemy.ChangeEnemyHand();
                enemy.ChangeRule();

                displayImage = false;
            }
        }
    }

    public void Rock()  // グー
    {
        if(displayImage == false)
        {
            if (enemy.ruleNum == 0)
            {
                if (enemy.enemyHand == 0)  // あいこ
                {
                    IncorrectAnswer();
                }
                else if (enemy.enemyHand == 1)  // 勝ち
                {
                    CorrectAnswer();
                }
                if (enemy.enemyHand == 2)  // 負け
                {
                    IncorrectAnswer();
                }
            }
            else
            {
                if (enemy.enemyHand == 0)
                {
                    IncorrectAnswer();
                }
                else if (enemy.enemyHand == 1)
                {
                    IncorrectAnswer();
                }
                if (enemy.enemyHand == 2)
                {
                    CorrectAnswer();
                }
            }
        }
    }

    public void Scissors()  // チョキ
    {
        if (displayImage == false)
        {
            if (enemy.ruleNum == 0)
            {
                if (enemy.enemyHand == 0)  // 負け
                {
                    IncorrectAnswer();
                }
                if (enemy.enemyHand == 1)  // あいこ
                {
                    IncorrectAnswer();
                }
                if (enemy.enemyHand == 2)  // 勝ち
                {
                    CorrectAnswer();
                }
            }
            else
            {
                if (enemy.enemyHand == 0)
                {
                    CorrectAnswer();
                }
                if (enemy.enemyHand == 1)
                {
                    IncorrectAnswer();
                }
                if (enemy.enemyHand == 2)
                {
                    IncorrectAnswer();
                }
            }
        }
    }

    public void Paper()  // パー
    {
        if (displayImage == false)
        {
            if (enemy.ruleNum == 0)
            {
                if (enemy.enemyHand == 0)  // 勝ち
                {
                    CorrectAnswer();
                }
                if (enemy.enemyHand == 1)  // 負け
                {
                    IncorrectAnswer();
                }
                if (enemy.enemyHand == 2)  // あいこ
                {
                    IncorrectAnswer();
                }
            }
            else
            {
                if (enemy.enemyHand == 0)
                {
                    IncorrectAnswer();
                }
                if (enemy.enemyHand == 1)
                {
                    CorrectAnswer();
                }
                if (enemy.enemyHand == 2)
                {
                    IncorrectAnswer();
                }
            }
        }
    }

    private void CorrectAnswer()
    {
        musicManager.PlaySE2();
        scoreManager.PlusScore();
        correctImage.SetActive(true);

        displayTime = 0;
        displayImage = true;
    }

    private void IncorrectAnswer()
    {
        musicManager.PlaySE3();
        scoreManager.MinusScore();
        incorrectImage.SetActive(true);

        displayTime = 0;
        displayImage = true;
    }
}
