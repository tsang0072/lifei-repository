using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SwitchScene : MonoBehaviour
{
    public GameObject doorCollier;
    //public GameObject Text_popUp;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay(Collider collider) 
    {
        //Text_popUp.SetActive(true);
        

        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene(sceneName);
            if(sceneName=="02Room"){
                // AudioManager.instance.PauseABM();
                // AudioManager.instance.PlayABM_OutdoorAudio();
            }else if(sceneName=="01Game"){
                // AudioManager.instance.PauseABM_Outdoor();
                // AudioManager.instance.PlayABMAudio();
            }
            
        }
    }
}
