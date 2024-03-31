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
        // �}�����o�c�̉摜���\������Ă���Ƃ�
        if(displayImage)
        {
            displayTime += Time.deltaTime;

            if (displayTime >= 0.5f)  // ��莞�Ԍo�߂ŉ摜������
            {
                correctImage.SetActive(false);
                incorrectImage.SetActive(false);
                enemy.ChangeEnemyHand();
                enemy.ChangeRule();

                displayImage = false;
            }
        }
    }

    public void Rock()  // �O�[
    {
        if(displayImage == false)
        {
            if (enemy.ruleNum == 0)
            {
                if (enemy.enemyHand == 0)  // ������
                {
                    IncorrectAnswer();
                }
                else if (enemy.enemyHand == 1)  // ����
                {
                    CorrectAnswer();
                }
                if (enemy.enemyHand == 2)  // ����
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

    public void Scissors()  // �`���L
    {
        if (displayImage == false)
        {
            if (enemy.ruleNum == 0)
            {
                if (enemy.enemyHand == 0)  // ����
                {
                    IncorrectAnswer();
                }
                if (enemy.enemyHand == 1)  // ������
                {
                    IncorrectAnswer();
                }
                if (enemy.enemyHand == 2)  // ����
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

    public void Paper()  // �p�[
    {
        if (displayImage == false)
        {
            if (enemy.ruleNum == 0)
            {
                if (enemy.enemyHand == 0)  // ����
                {
                    CorrectAnswer();
                }
                if (enemy.enemyHand == 1)  // ����
                {
                    IncorrectAnswer();
                }
                if (enemy.enemyHand == 2)  // ������
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
