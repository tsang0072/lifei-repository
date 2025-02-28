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
    public int currentCameraIndex = 0; // Index of the currently active camera

    public float zoomSpeed = 5f; 
    public float minFOV = 30f; // Minimum field of view (zoom in)
    public float maxFOV = 80f; // Maximum field of view (zoom out)

    public float minFollowOffset = 10f;
    public float maxFollowOffset = 40f;
    private Vector3 followOffset;

    public GameObject clueCamera;
    CinemachineBrain cinemachineBrain;

    UIManager uiManager;
    GameManager gameManager;

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
        //followOffset=virtualCameras[currentCameraIndex].GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
        cinemachineBrain=gameObject.GetComponent<CinemachineBrain>();

        uiManager=UIManager.instance;
        gameManager=GameManager.instance;   
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

       //HandleZoom();
       HandleZoom_followOffst();     
    }

     void SwitchToNextCamera()
    {
        currentCameraIndex++;

        if(!gameManager.isRoomB){
        if (currentCameraIndex > 1)
            {
            currentCameraIndex = 0; // Wrap around to the first camera
            }
        }else if(gameManager.isRoomB)
        {
            Debug.Log("In roomB");
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
        if(!gameManager.isRoomB){
        if (currentCameraIndex < 0)
        {
            currentCameraIndex = 1; // Wrap around to the last camera
        }
        }else if(gameManager.isRoomB)
        {
            Debug.Log("Back to Main");
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

        //Adjust the camera's field of view based on scroll input
        if (activeCamera != null)
        {
            float newFOV = activeCamera.m_Lens.FieldOfView - scrollInput * zoomSpeed;
            newFOV = Mathf.Clamp(newFOV, minFOV, maxFOV); // Clamp the FOV to min/max values
            activeCamera.m_Lens.FieldOfView = newFOV;
        }
        
    }
    void HandleZoom_followOffst(){
        //followOffset=virtualCameras[currentCameraIndex].GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
        CinemachineVirtualCamera activeCamera = virtualCameras[currentCameraIndex];
        followOffset=activeCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
        
        Vector3 zoomDir=followOffset.normalized;
        float zoomAmount=20f;
        if(Input.mouseScrollDelta.y<0){
            followOffset+=zoomDir*zoomAmount;
        }
        if(Input.mouseScrollDelta.y>0){
            followOffset-=zoomDir*zoomAmount;
        }
        if(followOffset.magnitude<minFollowOffset){
            followOffset=zoomDir*minFollowOffset;
        }
        if(followOffset.magnitude>maxFollowOffset){
            followOffset=zoomDir*maxFollowOffset;
        }
        activeCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset=
        Vector3.Lerp(activeCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset,followOffset,Time.deltaTime*zoomSpeed);
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
