using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class mastersounds : MonoBehaviour
{
    public AudioSource gameVolume;

    private void Start()
    {
        
        gameVolume.Play();
    }

    void Update()
    {
        if (pausingscript.isPaused)
        {

            gameVolume.Pause();
        }
        else
        {
            gameVolume.UnPause();
        }
    }

}


