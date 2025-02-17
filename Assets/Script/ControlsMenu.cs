using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public GameObject controlsMenu;
    public GameObject mainMenu;
    

    public void ControlsButton(){
        controlsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void BackButton(){
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
