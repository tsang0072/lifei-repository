using UnityEngine.SceneManagement;
using UnityEngine;


public class LoadGame : MonoBehaviour
{
    public string scenename;
    void Start()
    {
        Debug.Log("MainMenu Started");
    }

    public void LoadSceneA(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);

    }
}
