using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [DoNotSerialize]public static SoundManagerScript instance;
    [Header("------------Audio Source --------------")]
    [SerializeField]AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------------Audio Clips -------------")]
    public AudioClip background;
    public AudioClip Osox;
    public AudioClip Alejandra;
    public AudioClip Fosh;
    public AudioClip Patoto;
    public AudioClip Cameyoyo;
    public AudioClip Kotano;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else Destroy(gameObject);
    }

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(string bichoName) {
        switch (bichoName)
        {
            case "Osox":
                sfxSource.PlayOneShot(Osox); break;
            case "Alejandra":
                sfxSource.PlayOneShot(Alejandra); break;
            case "Fosh":
                sfxSource.PlayOneShot(Fosh); break;
            case "Patoto":
                sfxSource.PlayOneShot(Patoto); break;
            case "Cameyoyo":
                sfxSource.PlayOneShot(Cameyoyo); break;
            case "Kotano":
                sfxSource.PlayOneShot(Kotano); break;
            default:
                break;
        }
    }
}
