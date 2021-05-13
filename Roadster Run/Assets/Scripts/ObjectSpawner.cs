using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;
    public GameObject obj;
    public bool allowSpawn = true;

    public GameObject reset;
    public GameObject small;
    public GameObject medium;
    public GameObject large;
    public GameObject scenesOn;
    public GameObject scenesOff;
    public GameObject menu;
    public GameObject store;


    public void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();

        reset.SetActive(false);
        small.SetActive(false);
        medium.SetActive(false);
        large.SetActive(false);
        menu.SetActive(false);
        store.SetActive(false);
        scenesOff.SetActive(false);

        scenesOn.SetActive(true);
    }
    public void Update()
    {
        PlaceCar(); 
    }

    public void PlaceCar(){
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && allowSpawn == true) {
            obj = Instantiate(objectToSpawn, placementIndicator.transform.position, 
                placementIndicator.transform.rotation);
            allowSpawn = false;
            
            reset.SetActive(true);
            small.SetActive(true);
            medium.SetActive(true);
            large.SetActive(true);
            reset.SetActive(true);
        }
    }

    public void RemoveCar(){
        Destroy(obj);
        allowSpawn = true;

        reset.SetActive(false);
        small.SetActive(false);
        medium.SetActive(false);
        large.SetActive(false);
        reset.SetActive(false);
    }

    public void changeSize(string size){
        if(size == "small"){
            obj.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        }else if(size == "medium"){
            obj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }
        else if(size == "large"){
            obj.transform.localScale = new Vector3(1f, 0.2f, 1f);
        }
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

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoStore()
    {
        SceneManager.LoadScene("Store");
    }

}
