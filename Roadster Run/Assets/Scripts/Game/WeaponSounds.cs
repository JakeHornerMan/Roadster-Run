using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSounds : MonoBehaviour
{
    public static AudioClip snipershot, reload;
    static AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        snipershot = Resources.Load<AudioClip>("snipershot");
        reload = Resources.Load<AudioClip>("reload");
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "snipershot":
                audioSrc.PlayOneShot(snipershot);
                break;
            case "reload":
                audioSrc.PlayOneShot(reload);
                break;
        }
    }
}
