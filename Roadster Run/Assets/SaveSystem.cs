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
        dataCos.CarBody = "Delorian";
        dataCos.CarWheel = "Wheel1";

        SaveData(dataCos);
    }
    public static void SaveData(Cosmeticdata dataCos){

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/color.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, dataCos);
        stream.Close();
        Debug.Log("Saved Color :" + dataCos.CarColor);
    }

    public static Cosmeticdata LoadData(){
        string path = Application.persistentDataPath + "/color.data";
        if (File.Exists(path)){

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Cosmeticdata data = formatter.Deserialize(stream) as Cosmeticdata;
            stream.Close();
            return data;
            //Debug.Log("Loaded Color :" + data.CarColor);

        }else{
            Debug.LogError("Issue finding data");
            return null;
        }

    }

    public static void useCosmeticData(){
        Cosmeticdata data = LoadData();
        color = data.CarColor;
    }
}

[System.Serializable]
public class Cosmeticdata
{
    public string CarColor;
    public string CarBody;
    public string CarWheel;
}