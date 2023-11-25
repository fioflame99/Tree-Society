using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string sceneToLoad;

    public void SwitchScene()
    {
        Debug.Log("Switching scene");
        SceneManager.LoadScene(sceneToLoad);
    }
}
