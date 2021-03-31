using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip arcade_jump, drums, fortnite, mario_coin, mario_jump, nice_shot, pacman, rickroll, sonic_rings, super_mario, zelda_secret, zelda_treasure;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        arcade_jump = Resources.Load<AudioClip>("arcade_jump");
        drums = Resources.Load<AudioClip>("drums");
        fortnite = Resources.Load<AudioClip>("fortnite");
        mario_coin = Resources.Load<AudioClip>("mario_coin");
        mario_jump = Resources.Load<AudioClip>("mario_jump");
        nice_shot = Resources.Load<AudioClip>("nice_shot");
        pacman = Resources.Load<AudioClip>("pacman");
        rickroll = Resources.Load<AudioClip>("rickroll");
        sonic_rings = Resources.Load<AudioClip>("sonic_rings");
        super_mario = Resources.Load<AudioClip>("super_mario");
        zelda_secret = Resources.Load<AudioClip>("zelda_secret");
        zelda_treasure = Resources.Load<AudioClip>("zelda_treasure");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayRandomSound()
    {
        var audioArray = new List<AudioClip> {arcade_jump, drums, fortnite, mario_coin, mario_jump, nice_shot, pacman, rickroll, sonic_rings, super_mario, zelda_secret, zelda_treasure};
        int random = Random.Range(0, 11);
        audioSrc.PlayOneShot(audioArray[random], 0.1f);
    }
}
