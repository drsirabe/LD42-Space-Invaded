using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

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
