using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;

    [SerializeField] [Range(0f, 1f)] private float shootingVolume = 1f;
        
    [Header("DamageTaken")]
    [SerializeField] AudioClip damageTakenClip;
    [SerializeField] [Range(0f, 1f)] private float damageTakenVolume = 1f;

    private static AudioPlayer Instance;
    
    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(Instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayClipOnDamageTaken()
    {
        PlayClip(damageTakenClip, damageTakenVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
