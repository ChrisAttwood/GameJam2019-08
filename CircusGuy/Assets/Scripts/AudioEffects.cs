using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    public AudioSource AudioSource;


    public static AudioEffects instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayEffect(AudioClip clip,float pitchMin, float pitchMax)
    {
        AudioSource.clip = clip;
        AudioSource.pitch = Random.Range(pitchMin, pitchMax);
        AudioSource.Play();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
