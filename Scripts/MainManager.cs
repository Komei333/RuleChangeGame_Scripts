using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86;

public class MainManager : MonoBehaviour
{
    [SerializeField] MusicManager musicManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] TimeManager timeManager;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject scorePanel;
    [SerializeField] GameObject enemyRule;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        musicManager.PlaySE1();
        Time.timeScale = 1;
        timeManager.TimerStart();

        enemyRule.SetActive(true);
        startPanel.SetActive(false);
    }

    public void OpenMenu()
    {
        musicManager.PlaySE1();
        Time.timeScale = 0;

        menuPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void CloseMenu()
    {
        musicManager.PlaySE1();
        Time.timeScale = 1;

        mainPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void OpenScore()
    {
        scorePanel.SetActive(true);
        menuPanel.SetActive(false);
        mainPanel.SetActive(false);

        scoreManager.DecideRanking();
    }

    public void RetryButton()
    {
        musicManager.PlaySE1();
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnTitle()
    {
        musicManager.PlaySE1();
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScene");
    }
}
