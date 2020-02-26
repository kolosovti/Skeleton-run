using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameOverPanel;
    private GameController gameController;
    private static UiController instance;

    public static UiController Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject _ = GameObject.Find("Canvas");
                instance = _.GetComponent( typeof(UiController) ) as UiController;
            }
            return instance;
        }
    }

    void Start()
    {
        gameController = GameController.Instance;
    }

    void OnValidate()
    {
        mainMenuPanel = transform.Find("MainMenuPanel").gameObject;
        gameOverPanel = transform.Find("GameOverPanel").gameObject;
    }

    public void OnClickPLay()
    {
        gameController.StartGame();
        mainMenuPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
