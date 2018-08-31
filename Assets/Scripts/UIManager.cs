using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject pausePanel;
    public GameObject inGamePanel;
   
    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void Win()
    {
        inGamePanel.SetActive(false);
        winPanel.SetActive(true);
    }

    public void Lose()
    {
        inGamePanel.SetActive(false);
        losePanel.SetActive(true);
    }

    public void Pause()
    {
        inGamePanel.SetActive(false);
        pausePanel.SetActive(true);
    }
}
