using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverScreen;
    public Health GooseHealth;
    public Health BreadHealth; 
    
    public void CheckForGameOverState(Health targetHealth)
    {
        if (targetHealth.HP < 1)
        {
            GameOverScreen.SetActive(true);
        }
    }
}
