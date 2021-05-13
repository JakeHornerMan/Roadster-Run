using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCarVisuals : MonoBehaviour
{
    [SerializeField] public static Material playerColor;
    //public static List<ColorType> colortypes;

    public static Cosmeticdata data;

    public string color;

    public string body;

    //public GameObject coshandler;


    public void Start(){
        
        data = SaveSystem.LoadData();
        
        Debug.Log("car color loads :" + data.CarColor);
        Debug.Log("car color loads :" + data.CarBody);
        //settingColorsInList(colortypes);
        
        color = data.CarColor.ToString();
        GetComponent<CosmeticColors>().setColor(color);

        body = data.CarBody.ToString();
        GetComponent<CosmeticCarBody>().setBody(body);

    }
}

