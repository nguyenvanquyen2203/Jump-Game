using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private float volumn = 1;
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }
    public Sound[] musicSounds;
    public Sound[] SFXSounds;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
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
        PlayMusic("Background");
    }
    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(SFXSounds, s => s.name == name);
        sound.LoopMusic(false);
        sound.PlayMusic(volumn);
    }
    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, s => s.name == name);
        sound.LoopMusic(true);
        sound.PlayMusic(volumn);
    }
/*    public void StopSFX() { SFXSource.Stop(); }
    public void StopMusic() { musicSource.Stop(); }*/
    public void SetVolumn(float _volumn)
    {
        volumn = _volumn;
        foreach (Sound s in musicSounds) s.ChangeVolumn(volumn);
    } 
}
