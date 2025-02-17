using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject viewCanvas;
    public GameObject clueMenu;
    public GameObject clueListButton;

    public bool isPaused=false;
    public GameObject pauseMenu;
    public GameObject pauseMenuButton;


    public bool isClueMenu=false;
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

    // public void ShowViewCanvas(){
    //     gameManager.PauseGame();
    //     cameraManager.SwitchToClueCamera();
    //     viewCanvas.SetActive(true);
    //     clueList.SetActive(false);
    //     clueListButton.SetActive(false);
    // }

    // public void BackToClueList(){
    //     gameManager.PauseGame();
    //     cameraManager.SwitchToVirtualCamera();
    //     viewCanvas.SetActive(false);
    //     clueList.SetActive(true);
    //     clueListButton.SetActive(true);
    // }

    public void TriggerClueList(){
        if(!isClueMenu){
            gameManager.PauseGame();
            cameraManager.SwitchToClueCamera();

            isClueMenu = true;
            clueMenu.SetActive(true);
            pauseMenuButton.SetActive(false);
        }else{
            gameManager.PauseGame();
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
    public void Exit(){
        Application.Quit();
    }
}
