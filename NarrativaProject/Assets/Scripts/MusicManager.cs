using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource mainMusicSource;
    public AudioClip[] mainMusicClips;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMainMusic(int musicChoose)
    {
        mainMusicSource.clip = mainMusicClips[musicChoose];
        mainMusicSource.Play();
    }
}
