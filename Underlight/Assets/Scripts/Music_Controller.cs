using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject monster;
    [SerializeField] private AudioSource jukebox; 
    [SerializeField] private AudioSource monsterMusic;
    [SerializeField] private GameObject player;
    [SerializeField] private float musicDistance;
    [SerializeField] private bool musicSwitch;
    bool playingMonster = false;
    bool playingJukebox = true;
    
    void Start()
    {
        monsterMusic.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(musicSwitch == false){
            return;
        }
        float distance = Vector3.Distance(monster.transform.position, player.transform.position);
        if(distance<musicDistance){
            if(playingJukebox == false){
            jukebox.Stop();
            monsterMusic.Play();
            playingJukebox = true;
            playingMonster = false;
            }
        }else{
             if(playingMonster == false){
            monsterMusic.Stop();
            jukebox.Play();
            playingJukebox = false;
            playingMonster = true;
             }
        }
        
    }
}
