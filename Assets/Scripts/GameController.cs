using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private bool isPaused;
    private bool levelComplete;
    private bool gameOver;
    private bool restart;
    private bool quit;

	void Start ()
    {
#if UNITY_EDITOR
        SceneManager.sceneLoaded += SceneLighting;
#endif
    }
	
	void Update ()
    {
        //if(Input.GetKeyDown(KeyCode.Escape))
            //isPaused = true
            //Deltatime 0

        if (Input.GetKeyDown(KeyCode.R))
            {
               SceneManager.LoadScene("Main");
                //Debug.Log("restart");
            }

        if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
               // Debug.Log("Quit");
            }
  

        //wait for seconds on wake??
    }

#if UNITY_EDITOR
    void SceneLighting(Scene scene, LoadSceneMode mode)
    {
        if (UnityEditor.Lightmapping.giWorkflowMode == UnityEditor.Lightmapping.GIWorkflowMode.Iterative)
        {
            DynamicGI.UpdateEnvironment();
        }
    }
#endif
}
