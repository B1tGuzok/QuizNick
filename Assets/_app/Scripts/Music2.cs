using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music2 : MonoBehaviour
{
    public AudioSource audioSrc2;
    public AudioClip enabledClick;

    private void Start()
    {
        audioSrc2 = GameObject.Find("BGMusic1").GetComponent<AudioSource>();
    }

    public void onButtonClick()
    {
        audioSrc2.PlayOneShot(enabledClick);
    }

    public void onVolumeButtonClick()
    {
        audioSrc2.mute = !audioSrc2.mute;
    }
}
