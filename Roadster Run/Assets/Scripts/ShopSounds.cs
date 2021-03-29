using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSounds : MonoBehaviour
{
    public static AudioClip paintspray, drill, carInstall;
    static AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        paintspray = Resources.Load<AudioClip>("paintspray");
        drill = Resources.Load<AudioClip>("drill");
        carInstall = Resources.Load<AudioClip>("carInstall");
    }
    public static void PlaySound(string sound)
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
