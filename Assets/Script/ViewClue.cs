using UnityEngine.EventSystems;
using UnityEngine;

public class ViewClue : MonoBehaviour
{
    public float moveSpeed;
    public GameObject roationAxis2;

    void Update()
    {
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
    
}
