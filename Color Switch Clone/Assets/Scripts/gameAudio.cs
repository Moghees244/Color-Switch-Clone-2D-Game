using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        playTheme();
    }

    public void playTheme()
    {
        source.clip = clips[0];
        source.Play();
    }

    public void onColorChange()
    {
        source.PlayOneShot(clips[1]);
    }
    public void onGameOver()
    {
        source.clip=clips[3];
        source.Play();
    }
}
