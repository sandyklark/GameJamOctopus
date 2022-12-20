using System;
using UnityEngine;

public class Collision2DPropagator : MonoBehaviour
{
    public Action Enter;
    public Action Exit;
    public Action Stay;
    public Action Trigger;

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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Duck"))
        {
            Trigger?.Invoke();
        }
       
    }
}
