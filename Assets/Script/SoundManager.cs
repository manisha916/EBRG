using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource bg;
    public Sound[] clips;

    private void Awake()
    {
        inst = this;
    }
    public void PlaySound(SoundName name)
    {
        foreach (var item in clips)
        {
            if (item.name == name)
            {
                audioSource.PlayOneShot(item.clip);
                break;
            }
        }
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
    public void SetVolume1(float volume)
    {
        bg.volume = volume;
    }

}

[System.Serializable]
public class Sound
{
    public SoundName name;
    public AudioClip clip;
}
public enum SoundName
{
    click, s1, s2, s3,gameOver,playerJump
}