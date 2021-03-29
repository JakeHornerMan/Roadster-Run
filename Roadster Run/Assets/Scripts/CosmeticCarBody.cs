using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticCarBody : MonoBehaviour
{
    public GameObject charger;
    public GameObject delorain;

    public void setDelorian(){
        charger.SetActive(false);
        delorain.SetActive(true);
    }

    public void setCharger(){
        charger.SetActive(true);
        delorain.SetActive(false);
    }
}

