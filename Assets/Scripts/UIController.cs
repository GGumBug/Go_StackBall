using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Common")]
    [SerializeField]
    private TextMeshProUGUI currentLevel;
    [SerializeField]
    private TextMeshProUGUI nextLevel;

    [Header("Main")]
    [SerializeField]
    private GameObject      mainPanel;

    [Header("InGame")]
    [SerializeField]
    private Image           levelProgressBar;
    [SerializeField]
    private TextMeshProUGUI currentScore;

    [Header("GameOver")]
    [SerializeField]
    private GameObject      gameOverPenel;
    [SerializeField]
    private TextMeshProUGUI textCurrentScore;
    [SerializeField]
    private TextMeshProUGUI textHighScore;

    [Header("GameClear")]
    [SerializeField]
    private GameObject      gameClearPenel;
    [SerializeField]
    private TextMeshProUGUI textLevelCompleted;

    private void Awake()
    {
        currentLevel.text   = (PlayerPrefs.GetInt("LEVEL")+1).ToString();
        nextLevel.text      = (PlayerPrefs.GetInt("LEVEL")+2).ToString();

        //Getint기본값이 0이므로 정의하지 않았다면 0이다.
        if (PlayerPrefs.GetInt("DEACTIVATEMAIN") == 0)  mainPanel.SetActive(true);
        else                                            mainPanel.SetActive(false);
    }

    public void GameStart()
    {
        mainPanel.SetActive(false);
    }

    public void GameOver(int currentScore)
    {
        textCurrentScore.text = $"SCORE\n{ currentScore.ToString()}";
        textHighScore.text = $"HIGHT SCORE\n{ PlayerPrefs.GetInt("HIGHSCORE")}";

        gameOverPenel.SetActive(true);

        PlayerPrefs.SetInt("DEACTIVATEMAIN", 0);
    }

    public void GameClear()
    {
        textLevelCompleted.text = $"LEVEL {(PlayerPrefs.GetInt("LEVEL") + 1)}\nCOMPLETED!";

        gameClearPenel.SetActive(true);

        PlayerPrefs.SetInt("DEACTIVATEMAIN", 1);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("DEACTIVATEMAIN", 0);
    }

    public float LevelProgressBar { set => levelProgressBar.fillAmount = value; }

    public int CurrentScore { set => currentScore.text = value.ToString(); }
}
