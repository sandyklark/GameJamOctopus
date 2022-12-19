using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bread") || col.gameObject.CompareTag("Duck") )
        {
           Destroy(this.gameObject);
        }
    }
}
