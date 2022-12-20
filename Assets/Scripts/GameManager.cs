using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverScreen;
   
    public Health GooseHealth;
    public Health BreadHealth;

    public TextMeshProUGUI _breadScoreText; 
    public TextMeshProUGUI _breadLivesText;
    
    public TextMeshProUGUI _gooseScoreText; 
    public TextMeshProUGUI _gooseLivesText;

    public TextMeshProUGUI timerText;
    
    public int GooseScore = 0;
    public int BreadScore = 0;

    public static GameManager Instance;


    public Sprite BreadSprite;
    public Sprite GooseSprite; 
    public Sprite DRAW; 
    private void Awake()
    {
        //Resetti that spaghetti
        GooseScore = 0;
        BreadScore = 0;
        Instance = this;
    }

    private void OnEnable()
    {
        InitialTimeSeconds = Time.time;
    }

    public float GameTimeSeconds = 60;
    public float InitialTimeSeconds;

    private bool _isGameOver;
    
    // private void Update()
    // {
    //     if (_isGameOver) return;
    //
    //     timerText.text = (GameTimeSeconds - Time.time - InitialTimeSeconds).ToString("00:00");
    //     
    //     if (Time.time > InitialTimeSeconds + GameTimeSeconds)
    //     {
    //         ProcessGameOver(GameOverState.Bread);
    //     }
    // }

    public void CheckForGameOverState(Health targetHealth)
    {
        if (_isGameOver) return;
        
        if (targetHealth.HP < 1)
        {
            GooseScore += (250 * GooseHealth.HP);
            ProcessGameOver(GameOverState.Goose);
        }
    }

    private enum GameOverState
    {
        Goose,
        Bread,
        Draw
    }
    
    private void ProcessGameOver(GameOverState state)
    {
        _isGameOver = true;
        switch (state)
        {
            case GameOverState.Goose:
                break;
            case GameOverState.Bread:
                break;
            case GameOverState.Draw:
                break;
        }
        
        
        if (GooseScore > BreadScore)
        {
            ToastService.Instance.SpawnToast("GOOSE WINS", GooseSprite);
        }
        else if  (BreadScore > GooseScore)
        {
            ToastService.Instance.SpawnToast("BREAD WINS", BreadSprite);
        }
        else
        {
            ToastService.Instance.SpawnToast("DRAW", DRAW);
        }
            
        _gooseScoreText.text = "GOOSE SCORE " + GooseScore;
        _breadScoreText.text = "BREAD SCORE " + BreadScore;
        GameOverScreen.SetActive(true);
    }
}
