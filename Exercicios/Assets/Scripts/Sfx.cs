using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    public AudioSource gunSound;

    public void playSound()
    {
        gunSound.Play();
    }
}
