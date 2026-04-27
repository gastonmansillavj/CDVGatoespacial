using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetSoundLevel(float _volume)
    {
        masterMixer.SetFloat("SFXVolumen", Mathf.Log10(_volume) * 20);
    }

    public void SetMusicLevel(float _volume)
    {
        masterMixer.SetFloat("MusicaVolumen", Mathf.Log10(_volume) * 20);
    }
}
