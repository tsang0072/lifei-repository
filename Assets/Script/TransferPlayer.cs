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
    ClueManager clueManager;

    void Start()
    {
        cameraManager=CameraManager.instance;
        gameManager=GameManager.instance;   
        clueManager=FindObjectOfType<ClueManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if(!gameManager.isRoomB&&clueManager.canChangeRoom){
                gameManager.isRoomB=true;
                ChangeToRoomB();
            }else if(gameManager.isRoomB&&clueManager.canCollect7){
                gameManager.isRoomB=false;
                ChangeToMian();
            }

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
