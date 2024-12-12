using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Boton : MonoBehaviour
{
    AudioSource sound;
    void Awake()
    {
        sound = GetComponent<AudioSource>();
    }
    
    void HandleClick()
    {
        sound.Play();
    }
}
