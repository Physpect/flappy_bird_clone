using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource src;
    public AudioClip click_sound;
    public AudioClip death_sound;
    public AudioClip coin_sound;
    

    public void play_click_sound()
    {
        if (!FindObjectOfType<Bird>().is_dead)
        {
            src.clip = click_sound;
            src.Play();
        }
    }
    public void play_death_sound()
    {
        src.clip = death_sound;
        src.Play();
    }
    public void play_coin_sound()
    {
        
            src.PlayOneShot(coin_sound);
    }
}
