using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float SceneLoadDelay = 2f;
    ScoreKeeper ScoreKeeper;

    private void Awake()
    {
        ScoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        ScoreKeeper.ResetScore();
        SceneManager.LoadScene("Scenes/GameScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOverScene()
    {

        StartCoroutine(WaitAndLoad("GameOver", SceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
