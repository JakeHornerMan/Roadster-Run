using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static GameObject grabthedata;
    public static string color;

//gather the data
    public static void dataBuilder(){
        grabthedata = GameObject.Find("StoreHandler"); //get object with the store setting scripts

        Cosmeticdata dataCos = new Cosmeticdata();
        dataCos.CarColor = grabthedata.GetComponent<CosmeticColors>().carcolor; // access the car color variable
        dataCos.CarBody = grabthedata.GetComponent<CosmeticCarBody>().carbody; // access the car body variable
        dataCos.CarWheel = "Wheel1"; //placeholder

        SaveData(dataCos); //pass the data to save function
    }

    // save the data
    public static void SaveData(Cosmeticdata dataCos){

        BinaryFormatter formatter = new BinaryFormatter();// instance of a binary bformatter
        string path = Application.persistentDataPath + "/cosmetic.data"; //create path and name for the save file
        FileStream stream = new FileStream(path, FileMode.Create); //the stream will creat o this path

        formatter.Serialize(stream, dataCos); // open stream and format to binary
        stream.Close(); //close the stream
        Debug.Log("Saved Color :" + dataCos.CarColor);
        Debug.Log("Saved Body :" + dataCos.CarBody);
        Debug.Log("Saved Wheel :" + dataCos.CarWheel);
    }

    public static Cosmeticdata LoadData(){
        string path = Application.persistentDataPath + "/cosmetic.data"; //set path again
        if (File.Exists(path)){ //does it exist

            BinaryFormatter formatter = new BinaryFormatter(); //new instance of binary formatter
            FileStream stream = new FileStream(path, FileMode.Open); //stream on path to open the file
            Cosmeticdata data = formatter.Deserialize(stream) as Cosmeticdata; //converts binary to Cosmetic data objet and save in data
            stream.Close();
            Debug.Log("Loaded Color: " + data.CarColor);
            Debug.Log("Loaded Body: " + data.CarBody);
            Debug.Log("Loaded Wheel: " + data.CarWheel);

            return data; //returns data to function caller
            //Debug.Log("Found data");
        }else{
            Debug.LogError("Issue finding data"); //issue finding the file pathe specified
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