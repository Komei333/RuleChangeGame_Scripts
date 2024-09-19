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
        // 713�~950, 60Hz
        Screen.SetResolution(713, 950, FullScreenMode.Windowed, 60);

        //BGM�X���C�_�[�𓮂��������̏�����o�^
        bgmSlider.onValueChanged.AddListener(SetBGM);

        //SE�X���C�_�[�𓮂��������̏�����o�^
        seSlider.onValueChanged.AddListener(SetSE);

        // �X���C�_�[�ɒl�𔽉f
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
            //-30�`0�ɕϊ��i���Ηʂ�dB�ɕϊ��j
            bgmValue = -30f + (value * 30f);
        }

        //�ۑ�
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
            //-30�`0�ɕϊ��i���Ηʂ�dB�ɕϊ��j
            seValue = -30f + (value * 30f);
        }

        //�ۑ�
        PlayerPrefs.SetFloat("SE", seValue);
        PlayerPrefs.Save();

        musicManager.SetSE();
    }
}
