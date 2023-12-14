using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Buttons : MonoBehaviour{

    //variables set up 
    public string nextScene;
    public string instructionpage;

    //methods for all of the buttons on the main menu
    public void Start_Button(){
        SceneManager.LoadScene(nextScene);
    }

    public void Exit_Button(){
        Application.Quit();
    }

    public void Instuctions(){
        SceneManager.LoadScene(instructionpage);
    }

    //will add credits screen and controls screen later

}
