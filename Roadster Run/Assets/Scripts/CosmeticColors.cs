using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticColors : MonoBehaviour
{
    [SerializeField] public Material playerColor;
    private IEnumerator coroutine;
    public static Cosmeticdata data;

    public string carcolor;
    public string carbody;

    public static List<ColorType> colortypes;

    private bool soundAvaliable = true;
    
    //SELECTED COLORS
    //ColorType darkblue, babyblue, lightred, red, darkred, pink, lightpink, purple, yellow, gold, silver, lime, green, black, white;
    //public List<ColorType> colortypes = new List<ColorType>();

    public void Start(){
        colortypes = new List<ColorType>();
        settingColorsInList(colortypes);
        data = SaveSystem.LoadData();
        carcolor = data.CarColor.ToString();
        //carbody = data.CarBody.ToString(); 
        Debug.Log("car color loads :" + data.CarColor);

        setColor(carcolor);
    }

    public void changeColor(string c){
        if(colortypes.Count == 0){
            Debug.LogError("Elements wount add");
        }
        else{
            for(int i =0; i < colortypes.Count; i++){
                if(colortypes[i].name == c){
                    playerColor.color = colortypes[i].color;
                    carcolor = c;
                    playsound();
                    SaveSystem.dataBuilder();
                }
            }
        }
    }

    public void setColor(string c){
         if(colortypes.Count == 0){
            Debug.LogError("Elements wount add");
        }
        else{
            for(int i =0; i < colortypes.Count; i++){
                if(colortypes[i].name == c){
                    playerColor.color = colortypes[i].color;
                }
            }
        }
    }
    public void playsound(){
        if(soundAvaliable == true){
            soundAvaliable = false;
            ShopSounds.PlaySound("paintspray");
            coroutine = waittoplay(1f);
            StartCoroutine(coroutine);
        }
    }
    
    IEnumerator waittoplay(float _waitTime){
        yield return new WaitForSeconds(_waitTime);
        soundAvaliable = true;
    }

    public void settingColorsInList(List<ColorType> colortypes){
        
        ColorType blue = new ColorType();
        blue.name ="blue";
        blue.color =new Color(0/255f,35/255f,142/255f);
        colortypes.Add(blue);

        ColorType darkblue = new ColorType();
        darkblue.name ="darkblue";
        darkblue.color  = new Color(2/255f,21/255f,80/255f);
        colortypes.Add(darkblue);

        ColorType babyblue = new ColorType();
        babyblue.name ="babyblue";
        babyblue.color = new Color(0/255f,35/255f,142/255f);
        colortypes.Add(babyblue);

        ColorType lightred = new ColorType();
        lightred.name ="lightred";
        lightred.color = new Color(219/255f,132/255f,128/255f);
        colortypes.Add(lightred);

        ColorType red = new ColorType();
        red.name ="red";
        red.color = new Color(193/255f,57/255f,50/255f);
        colortypes.Add(red);

        ColorType darkred = new ColorType();
        darkred.name ="darkred";
        darkred.color = new Color(79/255f,13/255f,0/255f);
        colortypes.Add(darkred);

        ColorType pink = new ColorType();
        pink.name ="pink";
        pink.color = new Color(205/255f,3/255f,177/255f);
        colortypes.Add(pink);

        ColorType lightpink = new ColorType();
        lightpink.name ="lightpink";
        lightpink.color = new Color(243/255f,130/255f,228/255f);
        colortypes.Add(lightpink);

        ColorType purple = new ColorType();
        purple.name ="purple";
        purple.color = new Color(63/255f,21/255f,57/255f);
        colortypes.Add(purple);

        ColorType yellow = new ColorType();
        yellow.name ="yellow";
        yellow.color = new Color(255/255f,239/255f,0/255f);
        colortypes.Add(yellow);

        ColorType gold = new ColorType();
        gold.name ="gold";
        gold.color = new Color(207/255f,184/255f,0/255f);
        colortypes.Add(gold);

        ColorType silver = new ColorType();
        silver.name ="silver";
        silver.color = new Color(171/255f,171/255f,171/255f);
        colortypes.Add(silver);

        ColorType lime = new ColorType();
        lime.name ="lime";
        lime.color = new Color(116/255f,239/255f,130/255f);
        colortypes.Add(lime);

        ColorType green = new ColorType();
        green.name ="green";
        green.color = new Color(30/255f,87/255f,36/255f);
        colortypes.Add(green);

        ColorType black = new ColorType();
        black.name ="black";
        black.color = new Color(39/255f,39/255f,39/255f);
        colortypes.Add(black);

        ColorType white = new ColorType();
        white.name ="white";
        white.color = new Color(224/255f,224/255f,224/255f);
        colortypes.Add(white);

    }
}

[System.Serializable]
public class ColorType {
    public string name;
    public Color color;
}