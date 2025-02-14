using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class yarn : MonoBehaviour
{   
//MinimalDialogueRunner dialogueRunner;
private DialogueRunner dialogueRunner;
private bool isCurrentConversation;
public string conversationStartNode;
private bool interactable;

PlayerController playerController;

public void Start() {
    dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    dialogueRunner.onDialogueComplete.AddListener(EndConversation);
    playerController=FindObjectOfType<PlayerController>();
}


private void StartConversation() {
    Debug.Log($"Started conversation with {name}.");
    isCurrentConversation = true;
    // TODO *begin animation or turn on speaker indicator or whatever* HERE
    dialogueRunner.StartDialogue(conversationStartNode);
}

private void EndConversation() {
    if (isCurrentConversation) { 
        // TODO *stop animation or turn off indicator or whatever* HERE
        isCurrentConversation = false;
    }
    Debug.Log($"Ended conversation with {name}.");
}

// make character not able to be clicked on
[YarnCommand("disable")]
public void DisableConversation() {
    interactable = false;
}

void OnTriggerEnter(Collider other){
    if(other.gameObject.CompareTag("Player")){
        //StartConversation();
        //dialogueRunner.StartDialogue("Cop");
        if(this.gameObject.CompareTag("Cop")){
            dialogueRunner.StartDialogue("Cop");

        }else if(this.gameObject.CompareTag("Victim")){
            dialogueRunner.StartDialogue("Victim");
        }
    }
}

}
