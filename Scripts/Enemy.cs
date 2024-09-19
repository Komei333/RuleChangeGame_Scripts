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
        ROCK = 0,  // �O�[
        SCISSORS = 1,     // �`���L
        PAPER = 2,  // �p�|
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
        ruleText.text = "�����Ă�������";
    }

    public void ChangeEnemyHand()
    {
        enemy_hand = (Enemy_HAND)UnityEngine.Random.Range(0, 3);

        if (enemy_hand == Enemy_HAND.ROCK)  // �O�[
        {
            spriteRenderer.sprite = handSprites[0];
        }
        else if (enemy_hand == Enemy_HAND.SCISSORS)   // �`���L
        {
            spriteRenderer.sprite = handSprites[1];
        }
        else if (enemy_hand == Enemy_HAND.PAPER)  // �p�[
        {
            spriteRenderer.sprite = handSprites[2];
        }

        // 2�A���œ�������o���Ȃ��悤�ɂ���
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
        // 1/2�̊m����true
        isRuleReversed = UnityEngine.Random.Range(0, 2) == 0;

        if (isRuleReversed)  // ���������̃��[�����t�]���Ă���ꍇ
        {
            ruleText.text = "�����Ă�������";
        }
        else
        {
            ruleText.text = "�����Ă�������";
        }

        // �O��Ɠ������[���������ꍇ
        if(isRuleReversed == isBeforeRuleReversed)
        {
            if (isSameRuleTwice)  // 3�A���œ������[���ɂȂ��Ă��܂��ꍇ
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
