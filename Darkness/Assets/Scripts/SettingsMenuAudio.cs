using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SettingsMenuAudio : MonoBehaviour
{

    public AudioMixer ourMixer;

    public void SetVol(float Volume)
    {
        ourMixer.SetFloat("Volume", Volume);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
