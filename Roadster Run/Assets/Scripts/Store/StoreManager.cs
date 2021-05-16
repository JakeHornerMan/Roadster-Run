using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> cosmetictabs;
    [SerializeField] private List<GameObject> colorbuttons;
    [SerializeField] private List<GameObject> bodybuttons;
    [SerializeField] private List<GameObject> wheelbuttons;
    
    private void Start(){
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        SetButtonSetInvisible(cosmetictabs);
        SetButtonSetInvisible(colorbuttons);
        SetButtonSetInvisible(bodybuttons);
        SetButtonSetInvisible(wheelbuttons);
    }

    //SET A LIST OF BUTTONS VISIBLE
    private void SetButtonSetVisible(List<GameObject> buttonset){
        foreach (GameObject g in buttonset){
            if(g.activeSelf != true){
                g.SetActive(true);
            }
        }
    } 
    //SET A LIST OF BUTTONS INVISIBLE
    private void SetButtonSetInvisible(List<GameObject> buttonset){
        foreach (GameObject g in buttonset){
            if(g.activeSelf != false){
                g.SetActive(false);
            }
        }
    }

    public void Cosmetics(){
        SetButtonSetVisible(cosmetictabs);
    }
    public void Colors(){
        SetButtonSetVisible(colorbuttons);
        SetButtonSetInvisible(bodybuttons);
        SetButtonSetInvisible(wheelbuttons);
    }
    public void Bodys(){
        SetButtonSetVisible(bodybuttons);
        SetButtonSetInvisible(colorbuttons);
        SetButtonSetInvisible(wheelbuttons);
    }
    public void Wheels(){
        SetButtonSetVisible(wheelbuttons);
         SetButtonSetInvisible(colorbuttons);
        SetButtonSetInvisible(bodybuttons);
    }
}
