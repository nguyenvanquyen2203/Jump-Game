using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }
    public AudioData audioData;
    public Sound[] musicSounds;
    public Sound[] SFXSounds;
    public enum Audio_Type
    {
        Music,
        SFX
    }
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in musicSounds)
        {
            AudioSource src = gameObject.AddComponent<AudioSource>();
            s.InitSrc(src);
        }
        foreach (Sound s in SFXSounds)
        {
            AudioSource src = gameObject.AddComponent<AudioSource>();
            s.InitSrc(src);
        }
    }
    void Start()
    {
        PlayMusic("Background");
    }
    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(SFXSounds, s => s.name == name);
        sound.LoopMusic(false);
        sound.PlayMusic(audioData.SFXVolumn);
    }
    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, s => s.name == name);
        sound.LoopMusic(true);
        sound.PlayMusic(audioData.musicVolumn);
    }
    public void SetVolumn(float _volumn, Audio_Type type)
    {
        if (type == Audio_Type.Music) SetMusicVol(_volumn);
        else SetSFXVol(_volumn);
    } 
    private void SetMusicVol(float _volumn)
    {
        audioData.musicVolumn = _volumn;
        foreach (Sound s in musicSounds) s.ChangeVolumn(_volumn);
    }
    private void SetSFXVol(float _volumn)
    {
        audioData.SFXVolumn = _volumn;
        foreach (Sound s in SFXSounds) s.ChangeVolumn(_volumn);
    }
    public float GetVolumn(Audio_Type type)
    {
        if (type == Audio_Type.Music) return audioData.musicVolumn;
        return audioData.SFXVolumn;
    }
}
