using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP_FuncAudioAleatorio : MonoBehaviour {

    [SerializeField] AudioClip[] audios;

    AudioListener audioListener;

    void Awake()
    {
        audioListener = FindObjectOfType<AudioListener>();
    }

    public void UP_ReproducirAudio()
    {
        AudioClip clip = audios[Random.Range(0, audios.Length)];
        AudioSource.PlayClipAtPoint(clip, audioListener.transform.position);
    }

}
