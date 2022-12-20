using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOfAudioSource : MonoBehaviour
{
    public AudioSource AudioSource;
    public void OnEnable()
    {
        AudioSource.enabled = false;
    }
}
