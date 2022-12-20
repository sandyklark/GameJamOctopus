using System;
using UnityEngine;

public class ToastService : MonoBehaviour
{

    public ToastPopup ToastPopup;

    public Transform SpawnPoint;

    public static ToastService Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //SpawnToast("You're Toast");
    }

    public void SpawnToast(string text, Sprite sprite)
    {
        ToastPopup toast = Instantiate(ToastPopup, SpawnPoint);
        toast.Setup(text, sprite);
        Destroy(toast, 5);
    }
}
