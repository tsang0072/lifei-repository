using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed=10f;
    public float stoppingDistance = 0.1f; 
    

    public NavMeshAgent agent; 

    private GameObject targetObject;
    private Vector3 targetPosition;

    DialogueRunner dialogueRunner;
    [SerializeField]ParticleSystem ClickEffect;
    [SerializeField]LayerMask clickableLayer;

    Animator anime;

    void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        targetPosition=new Vector3(5,1,23);
        anime=GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)&&!dialogueRunner.IsDialogueRunning)
        //freeze player movement when in dialogue
        {
            if(EventSystem.current.IsPointerOverGameObject())
            return;//prevent click through UI 
            else if(EventSystem.current.currentSelectedGameObject != null)
            return;
        

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit point is on the NavMesh
                if (NavMesh.SamplePosition(hit.point, out NavMeshHit navHit, 1.0f, NavMesh.AllAreas))
                {
                    // Set the NavMeshAgent's destination to the hit point
                    agent.SetDestination(navHit.position);
                    anime.SetBool("walk",true);
                    if (ClickEffect != null)
                    {Instantiate(ClickEffect,hit.point+=new Vector3(0, 0.1f,0),ClickEffect.transform.rotation);}
                }else{
                    anime.SetBool("walk",false);
                }
                
            }

            if (hit.collider.CompareTag("Interactable"))
                {
                    // Set the target object
                    targetObject = hit.collider.gameObject;

                    // Move to the target object's position
                    if (NavMesh.SamplePosition(targetObject.transform.position, out NavMeshHit navHit, 1.0f, NavMesh.AllAreas))
                    {
                        agent.SetDestination(navHit.position);
                    }
                }
            if (hit.collider.CompareTag("Suspect"))
                {
                    targetObject = hit.collider.gameObject;

                    // Move to the target object's position
                    if (NavMesh.SamplePosition(targetObject.transform.position, out NavMeshHit navHit, 1.0f, NavMesh.AllAreas))
                    {
                        agent.SetDestination(navHit.position);
                    }
                }
            if (hit.collider.CompareTag("Door")){
                targetObject = hit.collider.gameObject;
                if (NavMesh.SamplePosition(targetObject.transform.position, out NavMeshHit navHit, 1.0f, NavMesh.AllAreas))
                    {
                        agent.SetDestination(navHit.position);
                    }
                  
            }
            if (hit.collider.CompareTag("Cass")){
                targetObject = hit.collider.gameObject;
                if (NavMesh.SamplePosition(targetObject.transform.position, out NavMeshHit navHit, 1.0f, NavMesh.AllAreas))
                    {
                        agent.SetDestination(navHit.position);
                    }
                  
            }
        }
        
    }
}


