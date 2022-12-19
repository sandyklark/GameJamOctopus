using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f; 
    // Update is called once per frame
    void LateUpdate()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }
}
