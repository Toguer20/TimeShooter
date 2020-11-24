using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip backgroundMusic;
    public AudioClip scoreTarget;
    public AudioClip timeAddTarget;
    public AudioClip timeRemoveTarget;
    public AudioClip revolverSpin;
    public AudioClip revolverNoAmo;
    public AudioClip revolverReloadEnd;
    public AudioClip revolverReloadAmmo;
    public AudioClip revolverShoot;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
