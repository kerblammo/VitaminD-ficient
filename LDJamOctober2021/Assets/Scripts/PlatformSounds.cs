using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSounds : MonoBehaviour
{

    [SerializeField] AudioClip crackle;
    [SerializeField] AudioClip destruction;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayCrackle()
    {
        source.Stop();
        source.PlayOneShot(crackle);
        
    }

    public void PlayDestruction()
    {
        source.Stop();
        source.PlayOneShot(destruction);
        
        
    }

    
}
