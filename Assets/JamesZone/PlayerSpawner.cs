using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject Goose;

    public GameObject Bread; 
    // Start is called before the first frame update
    void Start()
    {
        PlayerInput.Instantiate(Goose, controlScheme: "Player1", pairWithDevice: Keyboard.current);
        PlayerInput.Instantiate(Bread, controlScheme: "Player2", pairWithDevice: Keyboard.current);
    }

}
