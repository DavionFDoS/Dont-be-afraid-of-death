using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    public string SceneToReload;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!string.IsNullOrEmpty(SceneToReload))
            {
                SceneManager.LoadScene(SceneToReload);
            }            
        }
    }
}
