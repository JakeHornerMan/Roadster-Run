using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausebtn;
    public GameObject playbtn;
    public GameObject mainMenu;
    public GameObject gameOver;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        pausebtn.SetActive(true);
        playbtn.SetActive(false);
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        pausebtn.SetActive(false);
        playbtn.SetActive(true);
        mainMenu.SetActive(true);
        Time.timeScale = 0;

    }
    public void Play()
    {
        pausebtn.SetActive(true);
        playbtn.SetActive(false);
        mainMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver(){
        gameOver.SetActive(true);
        mainMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
