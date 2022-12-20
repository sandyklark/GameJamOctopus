
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ToastPopup : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Image Image;

    public void Setup(string text, Sprite sprite )
    {
        Text.text = text;
        Image.sprite = sprite;
    }
}
