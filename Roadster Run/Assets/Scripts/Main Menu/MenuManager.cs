using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Start(){
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    // Start is called before the first frame update
    public void StartGame() {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void playAR()
    {
        SceneManager.LoadScene("AR Display");
    }
    public void playStore()
    {
        SceneManager.LoadScene("Store");
    }
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
