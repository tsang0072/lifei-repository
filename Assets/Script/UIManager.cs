using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject viewCanvas;
    public GameObject clueList;
    public GameObject clueListButton;

    public bool isPaused=false;
    public GameObject pauseMenu;
    public GameObject pauseMenuButton;


    public bool isListShowing=false;
    GameManager gameManager;
    CameraManager cameraManager; 
    ViewClue viewClue; 

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
        viewClue=GetComponent<ViewClue>();
    }

    public void ShowViewCanvas(){
        gameManager.PauseGame();
        cameraManager.SwitchToClueCamera();
        viewCanvas.SetActive(true);
        clueList.SetActive(false);
        clueListButton.SetActive(false);
    }

    public void BackToClueList(){
        gameManager.PauseGame();
        cameraManager.SwitchToVirtualCamera();
        viewCanvas.SetActive(false);
        clueList.SetActive(true);
        clueListButton.SetActive(true);
        //viewClue.CloseInspection();
    }

    public void TriggerClueList(){
        if(!isListShowing){
            isListShowing = true;
            clueList.SetActive(true);
            pauseMenuButton.SetActive(false);
        }else{
            clueList.SetActive(false);
            isListShowing=false;
            pauseMenuButton.SetActive(true);
        }
        
    }
    public void TriggerPauseMenu(){
        if(!isPaused){
            gameManager.PauseGame();
            pauseMenu.SetActive(true);
            isPaused = true;
            clueListButton.SetActive(false);
        }else{
            gameManager.PauseGame();
            pauseMenu.SetActive(false);
            isPaused=false;
            clueListButton.SetActive(true);
        }
    }
    public void Exit(){
        Application.Quit();
    }
}
