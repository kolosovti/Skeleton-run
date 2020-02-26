using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private IEnemySpawner spawner;
    private TimeController timeController;
    private UiController uiController;
    private static GameController instance;

    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameObject = new GameObject("GameController");
                instance = gameObject.AddComponent<GameController>();
            }
            return instance;
        }
    }

    void Start()
    {
        spawner = new GameObject("WallSpawner").AddComponent<WallSpawner>();
        uiController = UiController.Instance;
        timeController = TimeController.Instance;
        timeController.StopTime();
    }

    public void StartGame()
    {
        timeController.StartTime();
        spawner.SetActive(true);
    }

    public void GameOver()
    {
        spawner.SetActive(false);
        uiController.ShowGameOverPanel();
        timeController.StopTime();
    }
}