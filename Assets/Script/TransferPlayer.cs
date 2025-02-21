using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TransferPlayer : MonoBehaviour
{
    public Transform target1;
    public GameObject player; 
    

    CameraManager cameraManager;
    GameManager gameManager;

    void Start()
    {
        cameraManager=CameraManager.instance;
        gameManager=GameManager.instance;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if(!gameManager.isRoomB){
                gameManager.isRoomB=true;
                ChangeToRoomB();
            }else if(gameManager.isRoomB){
                gameManager.isRoomB=false;
                ChangeToMian();
            }




        //     if(!isRoomB)
        //     {
        //     NavMeshAgent agent = player.GetComponent<NavMeshAgent>();
        //     Debug.Log("Change to RB");

        //     agent.enabled = false;
        //     player.transform.position = target1.position;
        //     agent.enabled = true;

        //     isRoomB=true;
        //     cameraManager.SwitchCamera(2);
        //     cameraManager.currentCameraIndex=2;
        //     Destroy(this.gameObject);
        //    }
        //    else if(isRoomB)
        //    {
        //     NavMeshAgent agent = player.GetComponent<NavMeshAgent>();

        //     agent.enabled = false;
        //     player.transform.position = target1.position;
        //     agent.enabled = true;

        //     isRoomB=false;
        //     cameraManager.SwitchCamera(0);
        //     cameraManager.currentCameraIndex=0;
        //    }
       }
    }

    public void ChangeToRoomB(){
        NavMeshAgent agent = player.GetComponent<NavMeshAgent>();
            Debug.Log("Change to RB");

            agent.enabled = false;
            player.transform.position = target1.position;
            agent.enabled = true;

            cameraManager.SwitchCamera(2);
            cameraManager.currentCameraIndex=2;

            Destroy(this.gameObject);
    }

    public void ChangeToMian(){
        NavMeshAgent agent = player.GetComponent<NavMeshAgent>();

            agent.enabled = false;
            player.transform.position = target1.position;
            agent.enabled = true;

            cameraManager.SwitchCamera(0);
            cameraManager.currentCameraIndex=0;
    }
}
