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
        bodytypes = new List<BodyType>(); //set up array list of body types
        settingBodysInList(bodytypes); //populate arraylist
        
        data = SaveSystem.LoadData(); // loading data to set visuals
        carbody = data.CarBody.ToString();
        Debug.Log("car color loads :" + data.CarBody);
        
        setBody(carbody);
    }


    //Body Button pass in the correct body name
    public void changeBody(string b){
        if(bodytypes.Count == 0){
            Debug.LogError("Elements dont Exist"); // settingBodysInList() doesnt populate list
        }
        else{
            //loop through contents of bodytypes
            for(int i =0; i < bodytypes.Count; i++){
                if(bodytypes[i].name == b){ // name of body equal the input
                    bodytypes[i].body.SetActive(true);//set the body game objrct to true
                    carbody = b; // set string for save data
                    playsound();// play sound
                    SaveSystem.dataBuilder(); //save changeed data
                }
                else{ //name of body does notequal the input
                    bodytypes[i].body.SetActive(false); //set as invisible
                }
            }
        }
    }

    //set body in ever scene loaded
    public void setBody(string b){
        if(bodytypes.Count == 0){
            Debug.LogError("Elements wount add"); // settingBodysInList() doesnt populate list
        }
        else{
            //loop through contents of bodytypes
            for(int i =0; i < bodytypes.Count; i++){
                if(bodytypes[i].name == b){ // name of body equal the input
                    bodytypes[i].body.SetActive(true); //set the body game objrct to true
                }
                else{ //name of body does notequal the input
                    bodytypes[i].body.SetActive(false); //set as invisible
                }
            }
        }
    }


    public void playsound(){
        if(soundAvaliable == true){ //if sound isnt already playing
            soundAvaliable = false; //not allowed play more sound
            ShopSounds.PlaySound("carInstall"); //play sound 
            coroutine = waittoplay(0.5f); // wait to set soundAvaliable true
            StartCoroutine(coroutine);
        }
    }
    
    IEnumerator waittoplay(float _waitTime){
        yield return new WaitForSeconds(_waitTime);
        soundAvaliable = true; // now allowed play another sound
    }

    public void settingBodysInList(List<BodyType> bodytypes){
        
        BodyType charger = new BodyType(); //new carbody
        charger.name ="Charger";
        charger.body = GO_charger; //game object attached to player car
        bodytypes.Add(charger); //add to bodytypes list

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
