﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    ParticleSystem particless;
    public GameObject player;
    public Text Score;
    public Text TimerText;

    public int scoreNum;
    public float totalcoins;
    public float timeleft;
    public int timeRemaining;

    public float timerVaule;
    // Start is called before the first frame update
    void Start()
    {
        particless = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(timeleft % 60);
        TimerText.text = "Timer :" + timeRemaining.ToString();
        Score.text = "Score: " + scoreNum;
        if (scoreNum == totalcoins)
        {
            if (timeleft <= timerVaule)
            {
                SceneManager.LoadScene("Win");
                Cursor.visible = true;
            }
        }
        else if (timeleft <= 0)
        {
            SceneManager.LoadScene("Lose");
            Cursor.visible = true;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Points")
        {
            particless.Play();
            scoreNum = scoreNum += 10;
            Destroy(other.gameObject);
        }
    
        else if (other.gameObject.tag == "water")
        {
            SceneManager.LoadScene("Lose"); 
            Cursor.visible = true;

        }
    }
}
