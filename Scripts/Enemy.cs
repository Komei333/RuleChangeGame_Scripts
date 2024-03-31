using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Text ruleText;

    public int enemyHand;
    private int beforeHand;

    public int ruleNum;
    private int beforeRule;
    private int ruleCount;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        beforeHand = 0;
        beforeRule = 0;
        ruleCount = 0;

        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeEnemyHand();

        ruleNum = 0;
        ruleText.text = "�����Ă�������";
    }

    public void ChangeEnemyHand()
    {
        enemyHand = UnityEngine.Random.Range(0, 3);

        if (enemyHand == 0)  // �O�[
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if (enemyHand == 1)   // �`���L
        {
            spriteRenderer.sprite = sprites[1];
        }
        else  // �p�[
        {
            spriteRenderer.sprite = sprites[2];
        }

        // 2�A���œ�����ɂȂ�Ȃ��悤�ɂ���
        if(enemyHand == beforeHand)
        {
            ChangeEnemyHand();
        }
        else
        {
            beforeHand = enemyHand;
        }
    }

    public void ChangeRule()
    {
        ruleNum = UnityEngine.Random.Range(0, 2);

        if (ruleNum == 0)
        {
            ruleText.text = "�����Ă�������";
        }
        else if (ruleNum == 1)
        {
            ruleText.text = "�����Ă�������";
        }

        if(ruleNum == beforeRule)
        {
            if(ruleCount == 0) // 2�A���œ������[���̏ꍇ
            {
                beforeRule = ruleNum;
                ruleCount = 1;
            }
            else  // 3�A���œ������[���̏ꍇ
            {
                ChangeRule();
            }
        }
        else
        {
            beforeRule = ruleNum;   
            ruleCount = 0;
        }
    }
}
