using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicController : MonoBehaviour
{
    private AudioClip audioClip;
    public AudioSource clip;
    public string MicName;
    public int segundos = 10;
    private bool isRecording = false;


    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in Microphone.devices)
        {
            MicName = item;
            Debug.Log(item);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isRecording)
            {
                Debug.Log("Grabando...");
                StartCoroutine(startRecord());
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (clip != null && !clip.isPlaying)
            {
                clip.loop = true;
                clip.Play();
            }
        }


    }


    private IEnumerator startRecord()
    {
        isRecording = true;
        //audioClip = Microphone.Start("Realtek High Definition Audio", false, 10, 44100);
        audioClip = Microphone.Start(MicName, false, segundos, 44100);

        yield return new WaitForSeconds(segundos);
        Debug.Log("Fin Grabacion...");

        if (isRecording)
            clip.clip = audioClip;

        isRecording = false;
    }
}
