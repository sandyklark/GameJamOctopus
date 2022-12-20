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

    public void CheckForGameOverState(Health targetHealth)
    {
        if (targetHealth.HP < 1)
        {
            _gooseScoreText.text = "GOOSE SCORE " + GooseScore;
            _breadScoreText.text = "BREAD SCORE " + BreadScore;
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
            GameOverScreen.SetActive(true);
        }
    }
}
