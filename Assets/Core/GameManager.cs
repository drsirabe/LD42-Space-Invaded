using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] Text timeRemainingText;
    [SerializeField] float levelTime;
    float timeRemaining;

    private void Start()
    {
        timeRemaining = levelTime;
        timeRemainingText.text = "Time until escape: " + Mathf.RoundToInt(timeRemaining).ToString();
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        timeRemainingText.text = "Time until escape: " + Mathf.RoundToInt(timeRemaining).ToString();

        if(timeRemaining <= 0f)
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void WinScreen()
    {
        SceneManager.LoadScene("Win");
    }

    public void LoseScreen()
    {
        SceneManager.LoadScene("Lose");
    }

    public void MenuScreen()
    {
        SceneManager.LoadScene("Menu");
    }

}
