using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //ClueMenu 
    public GameObject clueMenu;
    public GameObject clueListButton;
    public GameObject[] clueIntros;
    private GameObject currentIntro;
    public bool isClueMenu=false;

    //PauseMenu
    public bool isPaused=false;
    public GameObject pauseMenu;
    public GameObject pauseMenuButton;


    GameManager gameManager;
    CameraManager cameraManager; 

    void Awake() {
        if(!instance){
            instance=this;
        }else if(instance!=this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        pauseMenu.SetActive(false);
        gameManager=GameManager.instance;
        cameraManager=CameraManager.instance;
    }

    public void TriggerClueMenu(){
        if(!isClueMenu){
            cameraManager.SwitchToClueCamera();

            isClueMenu = true;
            clueMenu.SetActive(true);
            pauseMenuButton.SetActive(false);
        }else{
            cameraManager.SwitchToVirtualCamera();

            clueMenu.SetActive(false);
            isClueMenu=false;
            pauseMenuButton.SetActive(true);
        }
        
    }
    public void TriggerPauseMenu(){
        if(!isPaused){
            gameManager.PauseGame();
            pauseMenu.SetActive(true);
            isPaused = true;
            clueListButton.SetActive(false);
            pauseMenuButton.SetActive(false);
        }else{
            gameManager.PauseGame();
            pauseMenu.SetActive(false);
            isPaused=false;
            clueListButton.SetActive(true);
            pauseMenuButton.SetActive(true);
        }
    }

    public void ShowClueIntro(int introIndex){
        if(currentIntro!=null){
            currentIntro.SetActive(false);
        }

        if (introIndex >= 0 && introIndex < clueIntros.Length){
            currentIntro=clueIntros[introIndex];
            currentIntro.SetActive(true);
        }else
        {
            Debug.LogWarning("Invalid clue intro index!");
        }
    }
    public void CLoseCLueIntro(){
        if(currentIntro!=null){
            currentIntro.SetActive(false);
        }
    }
    public void Exit(){
        Application.Quit();
    }


}
