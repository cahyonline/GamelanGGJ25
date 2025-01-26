using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio Instance;
    public AudioSource nuno;
    public AudioClip Pecah;
    public AudioClip BGm;
    public AudioClip Death;
    public AudioClip Jumper;
    void Awake()
    {
        if (Instance  == null )
        {
            Instance = this ; DontDestroyOnLoad(gameObject);
        }

        else Destroy(gameObject);
    }

    public void NunoSfx()
    {
        nuno.PlayOneShot(Pecah);
    }

    public void Jumpingu()
    {
        nuno.PlayOneShot(Jumper);
    }

    public void Deathing()
    {
        nuno.PlayOneShot(Death);
    }


}
