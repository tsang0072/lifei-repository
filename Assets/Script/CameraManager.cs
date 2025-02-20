using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
using System;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public CinemachineVirtualCamera[] virtualCameras; 
    //public CinemachineVirtualCamera[] RBvirtualCameras;
    [SerializeField] private int currentCameraIndex = 0; // Index of the currently active camera

    public float zoomSpeed = 5f; 
    public float minFOV = 30f; // Minimum field of view (zoom in)
    public float maxFOV = 80f; // Maximum field of view (zoom out)

    public GameObject clueCamera;
    CinemachineBrain cinemachineBrain;
    TransferPlayer transferPlayer;

    UIManager uiManager;

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
        // Activate the first virtual camera by default
        SwitchCamera(currentCameraIndex);
        cinemachineBrain=gameObject.GetComponent<CinemachineBrain>();
        transferPlayer=FindFirstObjectByType<TransferPlayer>();

        uiManager=UIManager.instance;
    }

    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject != null||uiManager.isPaused||uiManager.isClueMenu){
            return;//prevent rotate camera while viewing clue
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            SwitchToPreviousCamera();
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SwitchToNextCamera();
            
        }

       HandleZoom();
            
    }

     void SwitchToNextCamera()
    {
        currentCameraIndex++;

        if(!transferPlayer.isRoomB){
        if (currentCameraIndex > 1)
            {
            currentCameraIndex = 0; // Wrap around to the first camera
            }
        }else if(transferPlayer.isRoomB)
        {
            Debug.Log("Room changed");
            if (currentCameraIndex >= virtualCameras.Length)
            {
            currentCameraIndex = 2; // Wrap around to the first camera
            }
            }
        SwitchCamera(currentCameraIndex);
    }

    void SwitchToPreviousCamera()
    {
        currentCameraIndex--;
        if(!transferPlayer.isRoomB){
        if (currentCameraIndex < 0)
        {
            currentCameraIndex = 1; // Wrap around to the last camera
        }
        }else if(transferPlayer.isRoomB){;
            Debug.Log("Room changed");
            if (currentCameraIndex < 2)
            {
            currentCameraIndex = virtualCameras.Length - 1; 
            }
        }
        SwitchCamera(currentCameraIndex);
    }

    public void SwitchCamera(int index)
    {
        // Disable all virtual cameras
        foreach (var vcam in virtualCameras)
        {
            vcam.Priority = 0;
        }

        // Enable the selected virtual camera
        virtualCameras[index].Priority = 10;
    }

    void HandleZoom()
    {
        CinemachineVirtualCamera activeCamera = virtualCameras[currentCameraIndex];
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Adjust the camera's field of view based on scroll input
        if (activeCamera != null)
        {
            float newFOV = activeCamera.m_Lens.FieldOfView - scrollInput * zoomSpeed;
            newFOV = Mathf.Clamp(newFOV, minFOV, maxFOV); // Clamp the FOV to min/max values
            activeCamera.m_Lens.FieldOfView = newFOV;
        }
    }

    public void SwitchToClueCamera(){
        clueCamera.SetActive(true);
        CinemachineVirtualCamera activeCamera = virtualCameras[currentCameraIndex];
        activeCamera.gameObject.SetActive(false);
        Debug.Log("In Game camera is locked");
    }

    public void SwitchToVirtualCamera(){
        clueCamera.SetActive(false);
        CinemachineVirtualCamera activeCamera = virtualCameras[currentCameraIndex];
        activeCamera.gameObject.SetActive(true);
        Debug.Log("In Game camera is working");
    }
}
