using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ClueManager : MonoBehaviour
{
    private GameObject targetObject;
    public GameObject clue1Button;
    public GameObject clue2Button;
    public GameObject clue3Button;
    public GameObject clue4Button;
    // public GameObject clue5Button;
    // public GameObject clue6Button;
    // public GameObject clue7Button;
    // public GameObject clue8Button;
    public bool canChangeRoom=false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger of the target object
        if (other.gameObject.CompareTag("Interactable"))
        {
            targetObject=other.gameObject;

            if(other.gameObject.name=="Clue1"){
                clue1Button.SetActive(true);
            }
            if(other.gameObject.name=="Clue2"){
                clue2Button.SetActive(true);
            }
            if(other.gameObject.name=="Clue3"){
                clue3Button.SetActive(true);
            }
            if(other.gameObject.name=="Clue4"){
                clue4Button.SetActive(true);
            }

            Destroy(targetObject);

            Debug.Log("Clue Collected");
            
        }
        if(other.gameObject.CompareTag("Door")){
            canChangeRoom=true;
            Debug.Log("Room changed");
        }
    }
    
    
}
