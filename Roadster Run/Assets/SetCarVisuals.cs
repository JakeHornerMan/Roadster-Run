using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCarVisuals : MonoBehaviour
{
    [SerializeField] public Material playerColor;
    public static List<ColorType> colortypes;
    private Cosmeticdata data;


    public void Start(){
        settingColorsInList(colortypes);
        try{
            data = SaveSystem.LoadData();
            Debug.Log("loaded data" + data.CarColor);
        }catch{
            Debug.Log("Cant load data");
        }
        
        CarColorSetter(data.CarColor);
        Debug.Log("car color loads :" + data.CarColor);
        //SaveSystem.useCosmeticData();
        //carcolor = SaveSystem.color;

        //CarColorSetter.playerColor = playerColor;
        //CarColorSetter.changeColor(carcolor);
    }
    
    public void CarColorSetter(string color){
        for(int i =0; i < colortypes.Count; i++){
            if(colortypes[i].name == color){
                playerColor.color = colortypes[i].color;
            }
        }
    }

    public void settingColorsInList(List<ColorType> clist){
        
        ColorType blue = new ColorType();
        blue.name ="blue";
        blue.color =new Color(0/255f,35/255f,142/255f);
        clist.Add(blue);

        ColorType darkblue = new ColorType();
        darkblue.name ="darkblue";
        darkblue.color  = new Color(2/255f,21/255f,80/255f);
        clist.Add(darkblue);

        ColorType babyblue = new ColorType();
        babyblue.name ="babyblue";
        babyblue.color = new Color(0/255f,35/255f,142/255f);
        clist.Add(babyblue);

        ColorType lightred = new ColorType();
        lightred.name ="lightred";
        lightred.color = new Color(219/255f,132/255f,128/255f);
        clist.Add(lightred);

        ColorType red = new ColorType();
        red.name ="red";
        red.color = new Color(193/255f,57/255f,50/255f);
        clist.Add(red);

        ColorType darkred = new ColorType();
        darkred.name ="darkred";
        darkred.color = new Color(79/255f,13/255f,0/255f);
        clist.Add(darkred);

        ColorType pink = new ColorType();
        pink.name ="pink";
        pink.color = new Color(205/255f,3/255f,177/255f);
        clist.Add(pink);

        ColorType lightpink = new ColorType();
        lightpink.name ="lightpink";
        lightpink.color = new Color(243/255f,130/255f,228/255f);
        clist.Add(lightpink);

        ColorType purple = new ColorType();
        purple.name ="purple";
        purple.color = new Color(63/255f,21/255f,57/255f);
        clist.Add(purple);

        ColorType yellow = new ColorType();
        yellow.name ="yellow";
        yellow.color = new Color(255/255f,239/255f,0/255f);
        clist.Add(yellow);

        ColorType gold = new ColorType();
        gold.name ="gold";
        gold.color = new Color(207/255f,184/255f,0/255f);
        clist.Add(gold);

        ColorType silver = new ColorType();
        silver.name ="silver";
        silver.color = new Color(171/255f,171/255f,171/255f);
        clist.Add(silver);

        ColorType lime = new ColorType();
        lime.name ="lime";
        lime.color = new Color(116/255f,239/255f,130/255f);
        clist.Add(lime);

        ColorType green = new ColorType();
        green.name ="green";
        green.color = new Color(30/255f,87/255f,36/255f);
        clist.Add(green);

        ColorType black = new ColorType();
        black.name ="black";
        black.color = new Color(39/255f,39/255f,39/255f);
        clist.Add(black);

        ColorType white = new ColorType();
        white.name ="white";
        white.color = new Color(224/255f,224/255f,224/255f);
        clist.Add(white);

    }

}

