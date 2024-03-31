using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    [SerializeField, Header("表示させるテキスト")]
    Text[] rankingText = new Text[5];

    string[] ranking = { "1位", "2位", "3位", "4位", "5位" };
    int[] rankingValue = new int[5];


    public void GetRanking()
    {
        GetValue();

        // テキストを設定
        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = ranking[i] + " : " + rankingValue[i].ToString();
        }
    }

    public void SetRanking(int value)
    {
        GetValue();

        // 書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
            // 取得した値とRankingの値を比較して入れ替え
            if (value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = value;
                value = change;
            }
        }

        // 入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
            PlayerPrefs.Save();
        }
    }

    private void GetValue()
    {
        // ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
}