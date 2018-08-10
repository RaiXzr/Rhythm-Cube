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
}
