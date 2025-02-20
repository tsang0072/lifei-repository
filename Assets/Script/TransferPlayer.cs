using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TransferPlayer : MonoBehaviour
{
    public Transform target1; 
    public Transform target2;
    public GameObject player; 
    public bool isRoomB=false;

    CameraManager cameraManager;

    void Start()
    {
        cameraManager=CameraManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if(!isRoomB)
            {
            NavMeshAgent agent = player.GetComponent<NavMeshAgent>();
            

            agent.enabled = false;
            player.transform.position = target1.position;
            agent.enabled = true;

            isRoomB=true;
            cameraManager.SwitchCamera(2);
           }
           else if(isRoomB)
           {
            NavMeshAgent agent = player.GetComponent<NavMeshAgent>();

            agent.enabled = false;
            player.transform.position = target2.position;
            agent.enabled = true;

            isRoomB=false;
            cameraManager.SwitchCamera(0);
           }
       }
    }
}
