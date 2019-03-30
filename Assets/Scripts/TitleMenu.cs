using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;
    [SerializeField]
    private GameObject creditsMenuPanel;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);

    }
    public void ExitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();

    }
    public void ShowCredits()
    {
        creditsMenuPanel.SetActive(true);

    }

}
