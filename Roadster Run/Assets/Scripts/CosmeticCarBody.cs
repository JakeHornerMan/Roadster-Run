using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticCarBody : MonoBehaviour
{
    
    //public GameObject GO_fordtruck;
    private IEnumerator coroutine;
    public static Cosmeticdata data;
    private bool soundAvaliable = true;

    public string carbody;
    public string carcolor;

    public static List<BodyType> bodytypes;
    public GameObject GO_charger;
    public GameObject GO_delorian;
    public GameObject GO_ford;

    public void Start(){
        bodytypes = new List<BodyType>();
        settingBodysInList(bodytypes);
        
        data = SaveSystem.LoadData();
        carbody = data.CarBody.ToString();
        //carcolor = data.CarColor.ToString();
        Debug.Log("car color loads :" + data.CarBody);
        
        setBody(carbody);
    }

    public void changeBody(string b){
        if(bodytypes.Count == 0){
            Debug.LogError("Elements dont Exist");
        }
        else{
            for(int i =0; i < bodytypes.Count; i++){
                if(bodytypes[i].name == b){
                    bodytypes[i].body.SetActive(true);
                    carbody = b;
                    playsound();
                    SaveSystem.dataBuilder();
                }
                else{
                    bodytypes[i].body.SetActive(false);
                }
            }
        }
    }

    public void setBody(string b){
        if(bodytypes.Count == 0){
            Debug.LogError("Elements wount add");
        }
        else{
            for(int i =0; i < bodytypes.Count; i++){
                if(bodytypes[i].name == b){
                    bodytypes[i].body.SetActive(true);
                }
                else{
                    bodytypes[i].body.SetActive(false);
                }
            }
        }
    }


    public void playsound(){
        if(soundAvaliable == true){
            soundAvaliable = false;
            ShopSounds.PlaySound("carInstall");
            coroutine = waittoplay(0.5f);
            StartCoroutine(coroutine);
        }
    }
    
    IEnumerator waittoplay(float _waitTime){
        yield return new WaitForSeconds(_waitTime);
        soundAvaliable = true;
    }

    public void settingBodysInList(List<BodyType> bodytypes){
        
        BodyType charger = new BodyType();
        charger.name ="Charger";
        charger.body = GO_charger;
        bodytypes.Add(charger);

        BodyType delorian = new BodyType();
        delorian.name ="Delorian";
        delorian.body = GO_delorian;
        bodytypes.Add(delorian);
        
        BodyType ford = new BodyType();
        ford.name ="Ford";
        ford.body = GO_ford;
        bodytypes.Add(ford);
    }
}

[System.Serializable]
public class BodyType {
    public string name;
    public GameObject body;
}
