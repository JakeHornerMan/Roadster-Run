using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static GameObject grabthedata;
    public static string color;

    public static void dataBuilder(){
        grabthedata = GameObject.Find("StoreHandler");

        Cosmeticdata dataCos = new Cosmeticdata();
        dataCos.CarColor = grabthedata.GetComponent<CosmeticColors>().carcolor;
        dataCos.CarBody = grabthedata.GetComponent<CosmeticCarBody>().carbody;
        dataCos.CarWheel = "Wheel1";

        SaveData(dataCos);
    }
    public static void SaveData(Cosmeticdata dataCos){

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/cosmetic.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, dataCos);
        stream.Close();
        Debug.Log("Saved Color :" + dataCos.CarColor);
        Debug.Log("Saved Body :" + dataCos.CarBody);
        Debug.Log("Saved Wheel :" + dataCos.CarWheel);
    }

    public static Cosmeticdata LoadData(){
        string path = Application.persistentDataPath + "/cosmetic.data";
        if (File.Exists(path)){

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Cosmeticdata data = formatter.Deserialize(stream) as Cosmeticdata;
            stream.Close();
            Debug.Log("Loaded Color: " + data.CarColor);
            Debug.Log("Loaded Body: " + data.CarBody);
            Debug.Log("Loaded Wheel: " + data.CarWheel);

            return data;
            //Debug.Log("Found data");
        }else{
            Debug.LogError("Issue finding data");
            return null;
        }

    }

    public static Cosmeticdata useCosmeticData(){
        Cosmeticdata data = LoadData();
        color = data.CarColor;
        Debug.Log("Loaded Data :" + color);
        return data;
        //SetCarVisuals.CosmeticColors(color);
    }
}

[System.Serializable]
public class Cosmeticdata
{
    public string CarColor;
    public string CarBody;
    public string CarWheel;
}