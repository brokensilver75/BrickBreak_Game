using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    bool gamePaused;
    [SerializeField] GameObject playButton, loserText, shield, replayButton;
    float score;
    [SerializeField] Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        loserText.SetActive(false);
        playButton.SetActive(true);
        replayButton.SetActive(false);
        gamePaused = true;
        Time.timeScale = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
           GamePauseCondition();
        } 
        
        if (shield.GetComponent<ShieldCollisions>().GetHealth() <= 0)
        {
            GameLose();
        }

        scoreText.text = score.ToString();

    }

    public void GamePauseCondition()
    {
        switch (gamePaused)
        {
            case true:
                gamePaused = false;
                Time.timeScale = 1;
                Debug.Log("Game Unpaused");
                playButton.SetActive(false);
                loserText.SetActive(false);
                break;
            case false:
                gamePaused = true;
                Time.timeScale = 0;
                Debug.Log("Game Paused");
                playButton.SetActive(true);
                break;
        }
    }

    public void GameLose()
    {
            loserText.SetActive(true);
            replayButton.SetActive(true);
            Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene("theGame");
    }

    public float GetScore ()
    {
        return score;
    }

    public void SetScore (float newScore)
    {
        score = newScore;
    }
}
