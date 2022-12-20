using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP = 4;

    public bool CanTakeDamage = true;

    public HealthUI HealthUI;
    public GameManager GameManager;
    public void TakeDamage()
    {
        if (CanTakeDamage == false)
        {
            return;
        }
        HP--;
        StartCoroutine(GodMode());
        HealthUI.RemoveHealth(HP);
        GameManager.CheckForGameOverState(this);
    }

    public IEnumerator GodMode()
    {
        CanTakeDamage = false; 
        yield return new WaitForSeconds(0.25f);
        CanTakeDamage = true; 
    }
}
