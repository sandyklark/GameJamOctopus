using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClsoeAfetrXSecondsLol : MonoBehaviour
{
    public GameObject Panel;
    private void OnEnable()
    {
        StartCoroutine(WaitToTurnOff());
    }

    public IEnumerator WaitToTurnOff()
    {
        yield return new WaitForSeconds(3.0f);
        Panel.SetActive(false);
    }
}
