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
        ruleText.text = "勝ってください";
    }

    public void ChangeEnemyHand()
    {
        enemyHand = UnityEngine.Random.Range(0, 3);

        if (enemyHand == 0)  // グー
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if (enemyHand == 1)   // チョキ
        {
            spriteRenderer.sprite = sprites[1];
        }
        else  // パー
        {
            spriteRenderer.sprite = sprites[2];
        }

        // 2連続で同じ手にならないようにする
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
            ruleText.text = "勝ってください";
        }
        else if (ruleNum == 1)
        {
            ruleText.text = "負けてください";
        }

        if(ruleNum == beforeRule)
        {
            if(ruleCount == 0) // 2連続で同じルールの場合
            {
                beforeRule = ruleNum;
                ruleCount = 1;
            }
            else  // 3連続で同じルールの場合
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
