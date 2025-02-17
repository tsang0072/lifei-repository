using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewClue : MonoBehaviour
{
    public float moveSpeed;
    public GameObject roationAxis2;

    // private GameObject targetObject;

    // private Transform targetPostison;
    // public GameObject CluePrefab;

    void Update()
    {
        //Transform.Rotate limits the rotation to the default settings' XYZ rotation
        //Euler Angles bases it on how it currently rests, making it more fun to play with.
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += moveSpeed * Time.deltaTime * new Vector3(0,30,0);        
            }    

        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += moveSpeed * Time.deltaTime * new Vector3(0,-30,0);        
        }  

        //euler X has a limit for whatever reason. using an empty, with a 90degrees set Y axis gives
        //the illusion of it working like a normal x
        if (Input.GetKey(KeyCode.W))
        {
            roationAxis2.transform.eulerAngles += moveSpeed * Time.deltaTime * new Vector3(0,0,30);
        }    

        if (Input.GetKey(KeyCode.S))
        {
            roationAxis2.transform.eulerAngles += moveSpeed * Time.deltaTime * new Vector3(0,0,-30);
        }  

    }
    // public void ShowClue(){
    //     if(targetObject != null){
            
    //         targetObject.SetActive(false);
    //     }
    //     targetObject=this.gameObject;
    //     targetObject.SetActive(true);
    // }
    // public void CloseInspection(){
    //     targetObject=this.gameObject;
    //     targetObject.SetActive(false);
    // }

    // public void DisplayClue(){
    //     if(targetPostison!=null){
    //         Destroy(targetPostison.gameObject);
    //     }
        
    // }
}
