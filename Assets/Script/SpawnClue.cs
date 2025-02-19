using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnClue : MonoBehaviour
{
    public GameObject[] cluePrefabs; 
    private GameObject currentPrefab; 

    // Method to spawn a prefab based on the button clicked
    void Start(){
        if (currentPrefab != null)
        {
            Destroy(currentPrefab);
        }
    }
    public void SpawnPrefab(int prefabIndex)
    {
        // Destroy the current prefab if it exists
        if (currentPrefab != null)
        {
            Destroy(currentPrefab);
        }

        // Check if the prefabIndex is valid
        if (prefabIndex >= 0 && prefabIndex < cluePrefabs.Length)
        {
            Vector3 spawnPosition=new Vector3(-12,133,225);
            currentPrefab = Instantiate(cluePrefabs[prefabIndex], spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Invalid prefab index!");
        }
    }

    public void ClosePrefab(){
        if (currentPrefab != null)
        {
            Destroy(currentPrefab);
        }

    }
}
