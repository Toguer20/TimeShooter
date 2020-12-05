﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static event Action PlayAgain = delegate { };
    [SerializeField] private float timer;
    private int score;
    public Canvas ScoreCanvas;
    public Text ScoreText;
    public Canvas CrosshairCanvas;
    public Canvas TimerCanvas;
    public Text TimerText;
    public static GameManager gm;
    public GameObject GameOverObject;
    //public float secondState;
    public Canvas ammoCanvas;
    public Text ammoText;
    private int coins;
    private int tickets;


    public int getTickets()
    {
        return tickets;
    }
    public void updateTickets(int num)
    {
        tickets = tickets + num;
    }
    public int getCoins()
    {
        return coins;
    }
    public void updateCoins(int num)
    {
        coins = coins + num;
    }

    public float raiseStateCooldown = 5f, startRaiseState = 30f;
        
    public void setAmmoCanvas(int ammo)
    {
        ammoText.text= "Ammo:"+ammo+" | 6";
    }

    public float Timer { get => timer; set => timer = value; }

    private void Start()
    {
      //  GetComponent<AudioSource>().clip = AudioManager.Instance.backgroundMusic;
      // GetComponent<AudioSource>().Play();
        if (gm == null)
        {
            gm = gameObject.GetComponent<GameManager>();
        }
        Cursor.visible = false;
    }

    public void UpdateScore(int num)
    {
        score = score + num;
        ScoreCanvas.GetComponentInChildren<Text>().text = "Score: " + score;
    }
    public void SetTimer(float num)
    {
        timer = Mathf.Max(timer - num, 0);
        //timer= Math.Truncate(timer);
        //  timer= (float)Math.Round(timer, 2);
        TimerText.text = "Time: " + timer.ToString("F2");
        if (timer == 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
	PlayAgain.Invoke();
        GameOverObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}