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

    public void PlaceCar(){
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && allowSpawn == true) {
            obj = Instantiate(objectToSpawn, placementIndicator.transform.position, 
                placementIndicator.transform.rotation);
            allowSpawn = false;
            
            placement.SetActive(false);

            manager.GetComponent<ARManager>().placedCar();  
        }
    }

    public void RemoveCar(){
        Destroy(obj);
        allowSpawn = true;
        placement.SetActive(true);
        manager.GetComponent<ARManager>().deletedCar();
    }

    public void changeSize(string size){
        if(size == "small"){
            obj.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        }else if(size == "medium"){
            obj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }
        else if(size == "large"){
            obj.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
