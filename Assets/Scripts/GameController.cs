using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject inGamePanel;

    public AudioSource music;

    private bool isPaused;
    private bool levelComplete;
    private bool gameOver;
    private bool resume;
    private bool restart;
    private bool quit;

    bool Paused = false; 

    public void ResumeLevel()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
        Paused = false;
        music.UnPause();
    }
    public void PauseLevel()
    {
        Time.timeScale = 0.0f;
        pausePanel.SetActive(true);
        Paused = true;
        music.Pause();
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
            //SceneManager.LoadScene("Main");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Debug.Log("restart");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //isPaused
            if (Paused == true)
            {
                ResumeLevel();
            }
            else
            {
                PauseLevel();
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
