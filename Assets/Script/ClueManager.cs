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
    public bool canAnime;
   [SerializeField] public int clueCount=0;

    void Start()
    {
        canAnime=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(clueCount==4){
            canChangeRoom=true;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger of the target object
        if (other.gameObject.CompareTag("Interactable"))
        {
            targetObject=other.gameObject;
            
            if(other.gameObject.name=="mace"){
                clue1Button.SetActive(true);
                clueCount++; 
                Destroy(targetObject);
            }
            if(other.gameObject.name=="glass"){
                clue3Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }
            if(other.gameObject.name=="Clue_Pharao"){
                clue4Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }if(other.gameObject.name=="bottle"){
                clue5Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }if(other.gameObject.name=="Clue6"){
                clue6Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }
            if(other.gameObject.name=="DamagedArtifact"){
                clue7Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }
            if(other.gameObject.name=="Clue8"){
                clue8Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
            }

            Debug.Log("Clue Collected");
            
        }
        
    }
    public void ShowKeyClue(){
        clue2Button.SetActive(true);
        clueCount++;
    }
    public void showClue7(){
        clue7Button.SetActive(true);
                clueCount++;
                Destroy(targetObject);
    }
    
}
