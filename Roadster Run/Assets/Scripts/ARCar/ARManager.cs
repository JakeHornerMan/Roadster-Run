using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARManager : MonoBehaviour
{
    public GameObject reset;
    public GameObject small;
    public GameObject medium;
    public GameObject large;
    public GameObject scenesOn;
    public GameObject scenesOff;
    public GameObject menu;
    public GameObject store;
    public GameObject capture;
    public GameObject logo;

    public void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        reset.SetActive(false);
        small.SetActive(false);
        medium.SetActive(false);
        large.SetActive(false);
        menu.SetActive(false);
        store.SetActive(false);
        scenesOff.SetActive(false);
        capture.SetActive(false);
        logo.SetActive(false);

        scenesOn.SetActive(true);
    }

    public void placedCar(){
        reset.SetActive(true);
        small.SetActive(true);
        medium.SetActive(true);
        large.SetActive(true);
        reset.SetActive(true);
        capture.SetActive(true);
    }

    public void deletedCar(){
        reset.SetActive(false);
        small.SetActive(false);
        medium.SetActive(false);
        large.SetActive(false);
        reset.SetActive(false);
        capture.SetActive(false);
    }

    public void sceneOptionsOn(){
        menu.SetActive(true);
        store.SetActive(true);

        scenesOn.SetActive(false);
        scenesOff.SetActive(true);
    }

    public void sceneOptionsOff(){
        menu.SetActive(false);
        store.SetActive(false);

        scenesOn.SetActive(true);
        scenesOff.SetActive(false);
    }

    public void imageSetup(){
        reset.SetActive(false);
        small.SetActive(false);
        medium.SetActive(false);
        large.SetActive(false);
        menu.SetActive(false);
        store.SetActive(false);
        scenesOff.SetActive(false);
        scenesOn.SetActive(false);
        capture.SetActive(false);
        
        logo.SetActive(true);
    }

    public void imagedone(){
        logo.SetActive(false);

        placedCar();
        scenesOn.SetActive(true);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoStore()
    {
        SceneManager.LoadScene("Store");
    }
}
