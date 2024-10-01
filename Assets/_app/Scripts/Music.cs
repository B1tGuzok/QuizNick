using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public GameObject BGMusic1;
    public AudioSource audioSrc1;
    public GameObject[] objs11;

    void Awake()
    {
        objs11 = GameObject.FindGameObjectsWithTag("Sound");
        if (objs11.Length == 0)
        {
            BGMusic1 = Instantiate(BGMusic1);
            BGMusic1.name = "BGMusic1";
            DontDestroyOnLoad(BGMusic1.gameObject);
        }
        else
        {
            BGMusic1 = GameObject.Find("BGMusic1");
        }
    }

    void Start()
    {
        audioSrc1 = BGMusic1.GetComponent<AudioSource>();
    }

    public AudioClip enabledClick;

    public void onButtonClick()
    {
        audioSrc1.PlayOneShot(enabledClick);
    }

    public void onVolumeButtonClick()
    {
        audioSrc1.mute = !audioSrc1.mute;
    }
}
