using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public List<GameObject> HealthNuggets = new List<GameObject>();
    public void RemoveHealth(int remainingHealth)
    {
        for (int i = 0; i < HealthNuggets.Count; i++)
        {
            HealthNuggets[i].SetActive(false);
        }
        
        for (int i = 0; i < remainingHealth; i++)
        {
            HealthNuggets[i].SetActive(true);
        }
    }
}
