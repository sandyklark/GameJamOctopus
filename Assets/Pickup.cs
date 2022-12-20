using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string ToastText;
    public Sprite Sprite;

    public int Score; 
    public void Awake()
    {
        if (Sprite is null)
        {
            Sprite = GetComponent<Sprite>();
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bread")  )
        {
          ToastService.Instance.SpawnToast(ToastText, Sprite);
          GameManager.Instance.GooseScore += Score; 
           Destroy(this.gameObject);
        }
        if ( col.gameObject.CompareTag("Duck") )
        {
            ToastService.Instance.SpawnToast(ToastText, Sprite);
            GameManager.Instance.GooseScore += Score; 
            Destroy(this.gameObject);
        }
    }
}
