using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private List<AudioClip> clips;
    [SerializeField] private AudioClip BGM;
    
    private AudioSource audioSource;
    private List<AudioSource> sfxPool = new List<AudioSource>();
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBGM();
    }
    
    public void OnStop()
    {
        StopBGM();
    }

    public void PlayBGM()
    {
        audioSource = GetAvailableSFXSource();

        audioSource.clip = BGM;
        audioSource.volume = 0.4f;
        audioSource.Play();
    }

    public void StopBGM()
    {
        PlaySFX(SFXType.StartButton);
        StartCoroutine(StopBGMCoroutine());
    }
    
    private IEnumerator StopBGMCoroutine()
    {
        while (audioSource.volume > 0f)
        {
            audioSource.volume -= Time.unscaledDeltaTime / 1.5f;
            yield return null;
        }
        audioSource.Stop();
    }
    
    public void PlaySFX(SFXType type)
    {
        AudioClip clip = GetAudioClip(type);
        AudioSource source = GetAvailableSFXSource();

        source.clip = clip;
        source.Play();
    }
    
    private AudioSource GetAvailableSFXSource()
    {
        foreach (AudioSource source in sfxPool)
        {
            if (!source.isPlaying)
            {
                source.volume = 1f;
                source.loop = false;
                return source;
            }
        }
    
        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        newSource.volume = 1f;
        newSource.playOnAwake = false;
        newSource.loop = false;
        sfxPool.Add(newSource);
        return newSource;
    }


    private AudioClip GetAudioClip(SFXType type) => clips[(int)type];
}