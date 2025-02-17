using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnClue : MonoBehaviour
{
    //public List<GameObject> CluePrefabs = new List<GameObject>();
    //public GameObject[] ClueButtons;

    public GameObject cluePrefab;
    //private Transform targetPostison;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowCluePrefab(){
        Vector3 targetPostison=new Vector3(0, 0, 0);

        if(targetPostison!=null){
            Destroy(gameObject);
        }
        Instantiate(cluePrefab, targetPostison , Quaternion.identity);

    }
}
