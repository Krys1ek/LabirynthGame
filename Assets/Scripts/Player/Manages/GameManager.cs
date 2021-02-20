using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public int TimeToEnd = 240;
    private bool gamePause = false;
    private bool EndGame = false;
    private bool win = false;

    


    private void Awake() 
    {
        if (gameManager == null)
            gameManager = this;
    }
    public void Endgame()
    {
        CancelInvoke("Stopper");
        if (win) {
            Debug.Log("You Win! Reload?");
        }
        else {
            Debug.Log("You Loose! Reload?");
        }
            
    }
    public void GamePause()
    {
        Debug.Log("GamePaused");
         gamePause = true;
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Debug.Log("GameResumed");
        gamePause = false;
        Time.timeScale = 1.0f;
    }
    public void Stopper() {

        TimeToEnd--;
        Debug.Log("Time:" + TimeToEnd + "s");
        if (TimeToEnd <= 0) {
            TimeToEnd = 0;
            EndGame = true;
        }
        if (EndGame)
        {
            Endgame();
        }
    }
    void Start() {
        InvokeRepeating("Stopper", 1, 1);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePause == true)
                ResumeGame();
            else
                GamePause();  

        }
    }
}
