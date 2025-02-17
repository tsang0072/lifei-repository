using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;



    public bool isPaused;

    public CinemachineBrain cinemachineBrain;

    void Awake() {
        if(!instance){
            instance=this;
        }else if(instance!=this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    

    

    public void PauseGame(){

        if (!isPaused)
        {
            Time.timeScale = 0; 
            //cinemachineBrain.enabled=false;
            isPaused=true;
        }
        else if(isPaused)
        {
            Time.timeScale = 1; 
            //cinemachineBrain.enabled=true;
            isPaused=false;
            
        }
        
    }
    
}

