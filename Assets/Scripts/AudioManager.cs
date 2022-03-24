using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager Instance;
    private AudioSource player;
    void Start()
    {
        Instance = this;
        player = GetComponent<AudioSource>();

    }
    public void Play(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>(name);
        player.PlayOneShot(clip);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
