using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSounds : MonoBehaviour
{
    public static AudioClip paintspray, drill, carInstall;
    static AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>(); //find audio source component

        //get sound resources
        paintspray = Resources.Load<AudioClip>("paintspray");
        drill = Resources.Load<AudioClip>("drill");
        carInstall = Resources.Load<AudioClip>("carInstall");
    }
    public static void PlaySound(string sound) //function called in other sctipts to play sound
    {
        switch (sound) 
        {
            case "paintspray":
                audioSrc.PlayOneShot(paintspray);
                break;
            case "drill":
                audioSrc.PlayOneShot(drill);
                break;
            case "carInstall":
                audioSrc.PlayOneShot(carInstall);
                break;
        }
    }
}
