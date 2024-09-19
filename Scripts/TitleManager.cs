using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86;

public class TitleManager : MonoBehaviour
{
    [SerializeField] MusicManager musicManager;
    [SerializeField] Ranking ranking;

    [SerializeField] GameObject titlePanel;
    [SerializeField] GameObject scorePanel;

    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;

    private float bgmValue;
    private float seValue;

    void Start()
    {
        // 713×950, 60Hz
        Screen.SetResolution(713, 950, FullScreenMode.Windowed, 60);

        //BGMスライダーを動かした時の処理を登録
        bgmSlider.onValueChanged.AddListener(SetBGM);

        //SEスライダーを動かした時の処理を登録
        seSlider.onValueChanged.AddListener(SetSE);

        // スライダーに値を反映
        bgmSlider.value = (PlayerPrefs.GetFloat("BGM") + 30f) / 30f;
        seSlider.value = (PlayerPrefs.GetFloat("SE") + 30f) / 30f;
    }

    public void StartGameButton()
    {
        musicManager.PlaySE1();
        SceneManager.LoadScene("GameScene");
    }

    public void OpenScore()
    {
        musicManager.PlaySE1();
        scorePanel.SetActive(true);
        titlePanel.SetActive(false);

        ranking.GetRanking();
    }

    public void CloseScore()
    {
        musicManager.PlaySE1();
        titlePanel.SetActive(true);
        scorePanel.SetActive(false);
    }

    public void SetBGM(float value)
    {
        if(value == 0)
        {
            bgmValue = -999f;
        }
        else
        {
            //-30～0に変換（相対量をdBに変換）
            bgmValue = -30f + (value * 30f);
        }

        //保存
        PlayerPrefs.SetFloat("BGM", bgmValue);
        PlayerPrefs.Save();

        musicManager.SetBGM();
    }

    public void SetSE(float value)
    {
        if (value == 0)
        {
            seValue = -999f;
        }
        else
        {
            //-30～0に変換（相対量をdBに変換）
            seValue = -30f + (value * 30f);
        }

        //保存
        PlayerPrefs.SetFloat("SE", seValue);
        PlayerPrefs.Save();

        musicManager.SetSE();
    }
}
