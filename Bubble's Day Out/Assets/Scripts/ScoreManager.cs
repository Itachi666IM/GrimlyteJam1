using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    int score;
    public float minTimeToNextPoint;
    public float maxTimeToNextPoint;
    float timeToNextPoint;
    float nextPointTime;

    [HideInInspector]public bool isPlayerDead = false;

    public GameObject bubbleEffect;
    public GameObject winPanel;
    public GameObject losePanel;

    public AudioSource audioSource;
    public AudioClip audioClip;
    bool once = false;
    // Start is called before the first frame update
    void Start()
    {
        timeToNextPoint = maxTimeToNextPoint;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlayerDead)
        {
            if (Time.time > nextPointTime)
            {
                score++;
                nextPointTime = Time.time + timeToNextPoint;
                timeToNextPoint -= (minTimeToNextPoint / maxTimeToNextPoint);
                if (timeToNextPoint < minTimeToNextPoint)
                {
                    timeToNextPoint = minTimeToNextPoint;
                }
            }
            scoreText.text = score.ToString();
        }
        else
        {
            if(!once)
            {
                once = true;
                audioSource.PlayOneShot(audioClip);
            }
            bubbleEffect.SetActive(false);
            if(score < 50)
            {
                losePanel.SetActive(true);
            }
            else
            {
                winPanel.SetActive(true);
            }
        }

    }

    public void RestarttGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
