using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Enemy;

public class JudgeManager : MonoBehaviour
{
    [SerializeField] MusicManager musicManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Enemy enemy;

    [SerializeField] GameObject correctImage;
    [SerializeField] GameObject incorrectImage;

    private float displayTime = 0;
    private bool isImageDisplayed = false;

    void Update()
    {
        // マルかバツの画像が表示されているとき
        if(isImageDisplayed)
        {
            displayTime += Time.deltaTime;

            if (displayTime >= 0.5f)  // 一定時間経過で画像を消す
            {
                correctImage.SetActive(false);
                incorrectImage.SetActive(false);
                enemy.ChangeEnemyHand();
                enemy.ChangeRule();

                isImageDisplayed = false;
            }
        }
    }

    public void RockButton()  // 自分がグーを出す
    {
        if(isImageDisplayed == false)
        {
            if (enemy.isRuleReversed)  // 勝ち負けのルールが逆転している場合
            {
                if (enemy.enemy_hand == Enemy_HAND.ROCK)
                {
                    IncorrectAnswer();
                }
                else if (enemy.enemy_hand == Enemy_HAND.SCISSORS)
                {
                    IncorrectAnswer();
                }
                if (enemy.enemy_hand == Enemy_HAND.PAPER)
                {
                    CorrectAnswer();
                }
            }
            else
            {
                if (enemy.enemy_hand == Enemy_HAND.ROCK)
                {
                    IncorrectAnswer();
                }
                else if (enemy.enemy_hand == Enemy_HAND.SCISSORS)
                {
                    CorrectAnswer();
                }
                if (enemy.enemy_hand == Enemy_HAND.PAPER)
                {
                    IncorrectAnswer();
                }
            }
        }
    }

    public void ScissorsButton()  // 自分がチョキを出す
    {
        if (isImageDisplayed == false)
        {
            if (enemy.isRuleReversed)  // 勝ち負けのルールが逆転している場合
            {
                if (enemy.enemy_hand == Enemy_HAND.ROCK)
                {
                    CorrectAnswer();
                }
                if (enemy.enemy_hand == Enemy_HAND.SCISSORS)
                {
                    IncorrectAnswer();
                }
                if (enemy.enemy_hand == Enemy_HAND.PAPER)
                {
                    IncorrectAnswer();
                }
            }
            else
            {
                if (enemy.enemy_hand == Enemy_HAND.ROCK)
                {
                    IncorrectAnswer();
                }
                if (enemy.enemy_hand == Enemy_HAND.SCISSORS)
                {
                    IncorrectAnswer();
                }
                if (enemy.enemy_hand == Enemy_HAND.PAPER)
                {
                    CorrectAnswer();
                }
            }
        }
    }

    public void PaperButton()  // 自分がパーを出す
    {
        if (isImageDisplayed == false)
        {
            if (enemy.isRuleReversed)  // 勝ち負けのルールが逆転している場合
            {
                if (enemy.enemy_hand == Enemy_HAND.ROCK)
                {
                    IncorrectAnswer();
                }
                if (enemy.enemy_hand == Enemy_HAND.SCISSORS)
                {
                    CorrectAnswer();
                }
                if (enemy.enemy_hand == Enemy_HAND.PAPER)
                {
                    IncorrectAnswer();
                }
            }
            else
            {
                if (enemy.enemy_hand == Enemy_HAND.ROCK)
                {
                    CorrectAnswer();
                }
                if (enemy.enemy_hand == Enemy_HAND.SCISSORS)
                {
                    IncorrectAnswer();
                }
                if (enemy.enemy_hand == Enemy_HAND.PAPER)
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
        isImageDisplayed = true;
    }

    private void IncorrectAnswer()
    {
        musicManager.PlaySE3();
        scoreManager.MinusScore();
        incorrectImage.SetActive(true);

        displayTime = 0;
        isImageDisplayed = true;
    }
}
