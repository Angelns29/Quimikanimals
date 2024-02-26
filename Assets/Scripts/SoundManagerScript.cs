using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [DoNotSerialize]public static SoundManagerScript soundManagerScript;
    [Header("------------Audio Source --------------")]
    [SerializeField]AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------------Audio Clips -------------")]
    public AudioClip background;
    public AudioClip quimikanimal1;
    public AudioClip quimikanimal2;
    public AudioClip quimikanimal3;
    public AudioClip quimikanimal4;
    public AudioClip quimikanimal5;
    public AudioClip quimikanimal6;


    void Awake()
    {
        if (soundManagerScript == null)
        {
            soundManagerScript = this;
            DontDestroyOnLoad(gameObject);

        }
        else Destroy(gameObject);
        musicSource.volume = 0.5f;
    }

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip audio) {
        sfxSource.PlayOneShot(audio);
    }
}
