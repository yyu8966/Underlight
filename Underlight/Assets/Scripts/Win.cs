using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    [SerializeField] private GameObject box;
    [SerializeField] private GameObject invisibleWalls;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject UI_Text;

    void OnTriggerStay2D(Collider2D other){
        //checks for collision of player with the box object and then sets UI and Invisible Walls to active
            print("collision entered");
            if(other.gameObject.tag == "Player"){
                    print("win!!");
                    UI_Text.SetActive(true);
                    invisibleWalls.SetActive(true);
                    Destroy(box);
            }
        }

}
