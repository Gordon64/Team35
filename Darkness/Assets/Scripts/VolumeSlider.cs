using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer audio;
    public void SetVolume (float volume)
    {
        audio.SetFloat("Volume", volume);
    }
}
