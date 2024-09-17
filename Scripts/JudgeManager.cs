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
        // �}�����o�c�̉摜���\������Ă���Ƃ�
        if(isImageDisplayed)
        {
            displayTime += Time.deltaTime;

            if (displayTime >= 0.5f)  // ��莞�Ԍo�߂ŉ摜������
            {
                correctImage.SetActive(false);
                incorrectImage.SetActive(false);
                enemy.ChangeEnemyHand();
                enemy.ChangeRule();

                isImageDisplayed = false;
            }
        }
    }

    public void RockButton()  // �������O�[���o��
    {
        if(isImageDisplayed == false)
        {
            if (enemy.isRuleReversed)  // ���������̃��[�����t�]���Ă���ꍇ
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

    public void ScissorsButton()  // �������`���L���o��
    {
        if (isImageDisplayed == false)
        {
            if (enemy.isRuleReversed)  // ���������̃��[�����t�]���Ă���ꍇ
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

    public void PaperButton()  // �������p�[���o��
    {
        if (isImageDisplayed == false)
        {
            if (enemy.isRuleReversed)  // ���������̃��[�����t�]���Ă���ꍇ
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
