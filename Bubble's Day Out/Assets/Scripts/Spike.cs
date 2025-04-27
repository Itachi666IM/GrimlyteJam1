using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            scoreManager.isPlayerDead = true;
        }
    }
}
