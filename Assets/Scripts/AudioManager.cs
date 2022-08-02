using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //public AudioSource[] audioSources;
    public static AudioManager instance;

    public AudioSource bombExplosionSound;

    private void Awake()
    {
        instance = this;
    }
    public void ExplosionSound()
    {
        bombExplosionSound.Play();
    }
}
