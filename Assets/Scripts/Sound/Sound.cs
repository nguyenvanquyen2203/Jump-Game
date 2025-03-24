using UnityEngine;
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    private AudioSource src;
    [Range(0f, 1f)]
    public float volumn;
    [Range(.1f, 3f)]
    public float pitch;
    public void PlayMusic(float _volumn)
    {
        src.volume = volumn * _volumn;
        src.Play();
    }
    public void InitSrc(AudioSource _src)
    {
        src = _src;
        src.clip = clip;
        src.pitch = pitch;
    }
    public void ChangeVolumn(float _volumn) => src.volume = _volumn * volumn; 
    public void LoopMusic(bool loop) => src.loop = loop;
}
