using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlatformSpawner platformSpawner;
    [SerializeField]
    private UIController    uiController;

    private RandomColor     randomColor;

    private int             brokePlatformCount = 0;
    private int             totalPlatformCount;
    private int             currentScore = 0;

    public bool             IsGamePlay { private set; get; }

    private void Awake()
    {
        totalPlatformCount = platformSpawner.SpawnPlatforms();

        randomColor = GetComponent<RandomColor>();
        randomColor.ColorHSV();
    }

    private IEnumerator Start()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();

                yield break;
            }

            yield return null;
        }
    }

    private void GameStart()
    {
        IsGamePlay = true;

        uiController.GameStart();
    }

    public void OnCollisionWithPlatform(int addedScore=1)
    {
        brokePlatformCount++;
        uiController.LevelProgressBar = (float)brokePlatformCount / (float)totalPlatformCount;

        currentScore += addedScore;
        uiController.CurrentScore = currentScore;
    }
}
