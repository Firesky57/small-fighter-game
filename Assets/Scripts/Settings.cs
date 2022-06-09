using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void settings(float volume)
    {
        Debug.Log("volume");
        audioMixer.SetFloat("Volume",volume);
    }
    
}
