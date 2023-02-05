using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audioscript : MonoBehaviour
{
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
    

    void Update()
    {
        if(!audio.isPlaying)
        {
            SceneManager.LoadScene(1);
        }
    }
}
