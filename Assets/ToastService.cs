using System;
using UnityEngine;

public class ToastService : MonoBehaviour
{

    public ToastPopup ToastPopup;

    public Transform SpawnPoint;

    private void Start()
    {
        SpawnToast("You're Toast");
    }

    public void SpawnToast(string text)
    {
        ToastPopup toast = Instantiate(ToastPopup, SpawnPoint);
        ToastPopup.Text.text = text; 
        Destroy(toast, 5);
    }
}
