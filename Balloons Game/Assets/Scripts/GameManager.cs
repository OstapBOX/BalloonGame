using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject scoreNull, gameOverNull;
    public Button restartButton;
    public AudioClip explodeSound;
    public AudioClip gameOverSound;
    public TextMeshProUGUI blueScoreText, pinkScoreText, purpleScoreText, gameOverStatisticText;
    public bool isGameActive;

    private AudioSource playerAudio;
    private int blueScore, pinkScore, purpleScore;
    private float force = 3, 
                  maxForce = 7.0f,  
                  increaseForceStep = 0.1f, 
                  spawnDelay = 1.0f, 
                  spawnInterval = 1.5f;
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        isGameActive = true;
        blueScore = 0;
        pinkScore = 0;
        purpleScore = 0;
        InvokeRepeating("IncreaseForce", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameActive)
        {
            CancelInvoke("IncreaseForce");
        }
    }

    private float IncreaseForce()
    {
        if (force < maxForce)
        {
            force += increaseForceStep;
        }
        return force;
    }

    public void GameOver()
    {
        isGameActive = false;
        scoreNull.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        gameOverNull.gameObject.SetActive(true);
        GameOverStatistic();
        playerAudio.PlayOneShot(gameOverSound, 0.9f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExplodeSound()
    {
        playerAudio.PlayOneShot(explodeSound, 0.7f);
    }

    public float GetForce()
    {
        return force;
    }
    public float GetDelay()
    {
        return spawnDelay;
    }
    public float GetInterval()
    {
        return spawnInterval;
    }

    public void UpdateBlueScore(int addScore)
    {
        blueScore += addScore;
        blueScoreText.text = "Blue: " + blueScore.ToString();
    }
    public void UpdatePinkScore(int addScore)
    {
        pinkScore += addScore;
        pinkScoreText.text = "Pink: " + pinkScore.ToString();
    }
    public void UpdatePurpleScore(int addScore)
    {
        purpleScore += addScore;
        purpleScoreText.text = "Purple: " + purpleScore.ToString();
    }

    public void GameOverStatistic()
    {
        gameOverStatisticText.text =  "\nBlue balloons: " + blueScore 
                                    + "\nPink balloons: " + pinkScore 
                                    + "\nPurple balloons: " + purpleScore;

    }
}
