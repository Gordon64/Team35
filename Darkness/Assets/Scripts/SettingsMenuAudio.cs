using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SettingsMenuAudio : MonoBehaviour
{

    public AudioMixer ourMixer;
    public Slider ourSlider;

    public void SetVol()
    {
        ourMixer.SetFloat("Volume", ourSlider.value);
    }
}
