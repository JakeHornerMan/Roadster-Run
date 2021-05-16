using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;
    public GameObject obj;
    public bool allowSpawn;

    public GameObject placement;

    public GameObject manager;

    public void Start()
    {
        allowSpawn= true;
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }
    public void Update()
    {
        PlaceCar(); 
    }

    public void PlaceCar(){ //places car in placement indicator space
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && allowSpawn == true) {
            obj = Instantiate(objectToSpawn, placementIndicator.transform.position, 
                placementIndicator.transform.rotation); // object spawned in place called obj
            allowSpawn = false;
            
            placement.SetActive(false); //hide placement indicator

            manager.GetComponent<ARManager>().placedCar();   // set ui
        }
    }

    public void RemoveCar(){ // remove obj
        Destroy(obj);
        allowSpawn = true; //allow Spawn for ar car
        placement.SetActive(true); //can see placement indicator
        manager.GetComponent<ARManager>().deletedCar(); //set ui for placing the car
    }

    public void changeSize(string size){
        if(size == "small"){ //button inputs small
            obj.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f); //toy car
        }else if(size == "medium"){ //button inputs medium
            obj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f); //remote control size car
        }
        else if(size == "large"){ //button inputs large
            obj.transform.localScale = new Vector3(1f, 1f, 1f); //real sized car
        }
    }
}
