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

    private void Awake()
    {
        currentLevel.text   = (PlayerPrefs.GetInt("LEVEL")+1).ToString();
        nextLevel.text      = (PlayerPrefs.GetInt("LEVEL")+2).ToString();
    }

    public void GameStart()
    {
        mainPanel.SetActive(false);
    }

    public float LevelProgressBar { set => levelProgressBar.fillAmount = value; }
}
