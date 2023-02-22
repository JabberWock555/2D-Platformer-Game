using System;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Singleton Script
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //-------

    public bool Mute = false;
    [Range(0,1)]
    public float Volume = 1f;

    public AudioSource SoundEffect;
    public AudioSource Music;
    public AudioSource Movement;

    public SoundType[] Sounds;

    private void Start()
    {
        PlayMusic(SoundEvents.BackgroundMusic);
    }

    private void Update()
    {
        
        AudioSetting(Volume, Mute);
       
    }

    public void PlayerMovement(SoundEvents sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            Movement.clip = clip;
            Movement.Play();
        }
        else
        {
            Debug.LogError("No Clip found for the event");
        }
    }

    public void PlayMusic(SoundEvents sound)
    {

        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {

            Music.clip = clip;
            Music.Play();
        }
        else
        {
            Debug.LogError("No Clip found for the event");
        }
    }

    public void Play(SoundEvents sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("No Clip found for the event");
        }
    }


    private void AudioSetting(float volume, bool status)
    {
        if (status)
        {
            Music.volume = 0;
            Movement.volume = 0;
            SoundEffect.volume = 0;
        }
        else
        {
            Music.volume = volume;
            SoundEffect.volume = volume;
            Movement.volume = volume;
        }
    }
   
    private AudioClip getSoundClip(SoundEvents sound)
    {
        SoundType Clip = Array.Find(Sounds, i => i.soundType == sound);

        if (Clip != null)
        {
            return Clip.soundClip;
        }
        else
        {
            return null;
        }
    }



}
[Serializable]
public class SoundType
{
    public SoundEvents soundType;
    public AudioClip soundClip;
}

public enum SoundEvents
{
    ButtonClick,
    BackgroundMusic,
    PlayerRun,
    PlayerJumpUp,
    PlayerLand,
    PlayerHurt,
    EnemyAttack,
    KeyPickup,
    PlayerDeath,
    PlayerWin
}

