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
    public GameObject clue5Button;
    public GameObject clue6Button;
    public GameObject clue7Button;
    public GameObject clue8Button;
    public bool canChangeRoom=false;
    public bool canBack=false;
    public bool canCollect7=false;
   [SerializeField] public int clueCount=0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(clueCount==4){
            canChangeRoom=true;
        }
        if(clueCount==6){
            canCollect7=true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger of the target object
        if (other.gameObject.CompareTag("Interactable"))
        {
            targetObject=other.gameObject;
            
            if(other.gameObject.name=="Clue1"){
                clue1Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }
            // if(other.gameObject.name=="Clue2"){
            //     clue2Button.SetActive(true);
            //     clueCount++;
            //     Destroy(targetObject);
            // }
            if(other.gameObject.name=="Clue3"){
                clue3Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }
            if(other.gameObject.name=="Clue4"){
                clue4Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }if(other.gameObject.name=="Clue5"){
                clue5Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }if(other.gameObject.name=="Clue6"){
                clue6Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }
            if(other.gameObject.name=="Clue7"&&canCollect7){
                clue7Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }
            if(other.gameObject.name=="Clue8"&&canCollect7){
                clue8Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }

            Debug.Log("Clue Collected");
            
        }
        
    }
    
    
}
