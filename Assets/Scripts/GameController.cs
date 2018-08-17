using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private bool isPaused;
    private bool levelComplete;
    private bool gameOver;
    private bool resume;
    private bool restart;
    private bool quit;

    bool Paused = false; 

    public void ResumeLevel()
    {

    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Start ()
    {
#if UNITY_EDITOR
        SceneManager.sceneLoaded += SceneLighting;
#endif
    }

    void Update()
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
            //isPaused
            if (Paused == true)
            {
                Time.timeScale = 1.0f;
                //Canvas.gameObject.SetActive(false);
                //Screen.showCursor = false;
                //Screen.lockCursor = true;
                //Camera.audio.Play();
                Paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                //Canvas.gameObject.SetActive(true);
                //Screen.showCursor = true;
                //Screen.lockCursor = false;
                //Camera.audio.Pause();
                Paused = true;

                //PauseMenu

                // Debug.Log("Quit");
            }


            //wait for seconds on wake??
        }
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
