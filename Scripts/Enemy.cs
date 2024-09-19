using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enemy;

public class Enemy : MonoBehaviour
{
    [SerializeField] Sprite[] handSprites;
    [SerializeField] Text ruleText;

    [SerializeField] GameObject enemyHand;

    public enum Enemy_HAND
    {
        ROCK = 0,  // グー
        SCISSORS = 1,     // チョキ
        PAPER = 2,  // パ－
    }
    public Enemy_HAND enemy_hand;

    private int beforeEnemyHand;

    public bool isRuleReversed;
    private bool isBeforeRuleReversed;
    private bool isSameRuleTwice;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        beforeEnemyHand = 0;

        spriteRenderer = enemyHand.GetComponent<SpriteRenderer>();
        ChangeEnemyHand();

        isRuleReversed = false;
        isBeforeRuleReversed = false;
        isSameRuleTwice = false;
        ruleText.text = "勝ってください";
    }

    public void ChangeEnemyHand()
    {
        enemy_hand = (Enemy_HAND)UnityEngine.Random.Range(0, 3);

        if (enemy_hand == Enemy_HAND.ROCK)  // グー
        {
            spriteRenderer.sprite = handSprites[0];
        }
        else if (enemy_hand == Enemy_HAND.SCISSORS)   // チョキ
        {
            spriteRenderer.sprite = handSprites[1];
        }
        else if (enemy_hand == Enemy_HAND.PAPER)  // パー
        {
            spriteRenderer.sprite = handSprites[2];
        }

        // 2連続で同じ手を出さないようにする
        if((int)enemy_hand == beforeEnemyHand)
        {
            ChangeEnemyHand();
        }
        else
        {
            beforeEnemyHand = (int)enemy_hand;
        }
    }

    public void ChangeRule()
    {
        // 1/2の確率でtrue
        isRuleReversed = UnityEngine.Random.Range(0, 2) == 0;

        if (isRuleReversed)  // 勝ち負けのルールが逆転している場合
        {
            ruleText.text = "負けてください";
        }
        else
        {
            ruleText.text = "勝ってください";
        }

        // 前回と同じルールだった場合
        if(isRuleReversed == isBeforeRuleReversed)
        {
            if (isSameRuleTwice)  // 3連続で同じルールになってしまう場合
            {
                ChangeRule();
                return;
            }
            else
            {
                isSameRuleTwice = true;
            }
        }
        else
        {
            isSameRuleTwice = false;
        }

        isBeforeRuleReversed = isRuleReversed;
    }
}
