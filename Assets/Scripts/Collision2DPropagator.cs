using System;
using UnityEngine;

public class Collision2DPropagator : MonoBehaviour
{
    public Action Enter;
    public Action Exit;
    public Action Stay;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Enter?.Invoke();
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        Exit?.Invoke();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Stay?.Invoke();
    }
}
