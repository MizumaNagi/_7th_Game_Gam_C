using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource player;

    void Start()
    {
        Instance = this;

        player = GetComponent<AudioSource>();

        Play("ClickBGM");
    }
    
    public void Play(string name)
    {

        AudioClip clip = Resources.Load<AudioClip>(name);


        //       AudioManager.Instance.Play("Jump");
        player.PlayOneShot(clip);
    }

}
