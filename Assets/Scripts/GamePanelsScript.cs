using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePanelsScript : MonoBehaviour
{
    public bool paused;
    public bool isGameActive;
    public GameObject pausePanel;
    public GameObject lvlCompletePanel;

    private void Start() 
    {
        PlayerMovement.lvlComplete = false;
        Time.timeScale = 1;
        paused = false;
        // isGameActive = true;
    }

    private void Update()
    {
        if(!lvlCompletePanel.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                ChangePaused();
            }
        }

        if(PlayerMovement.lvlComplete)
        {
            lvlCompletePanel.SetActive(true);
            
        }

    }
    //Every time this object is activated, the functions inside it run again.

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void ChangePaused()
    {
        
        if (!paused)
        {
            paused = true;
            pausePanel.SetActive(true);
            //savedVolume = AudioListener.volume;
            //AudioListener.volume = 0;
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pausePanel.SetActive(false);
            //AudioListener.volume = savedVolume;
            Time.timeScale = 1;

        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
//730