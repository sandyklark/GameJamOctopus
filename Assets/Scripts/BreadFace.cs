using System;
using System.Linq;
using UnityEngine;

public class BreadFace : MonoBehaviour
{
    public Sprite normalFace;
    public Sprite ouchFace; 
    public Sprite touchingFace; 
    
    public SpriteRenderer face;
    public SpriteRenderer bread;

    public Gradient burnColor;
    [Range(0f, 1f)]
    public float burntness = 0f;
    
    // private Rigidbody2D _rigidbody;
    private void Awake()
    {
        GetComponentsInChildren<Collision2DPropagator>()
            .ToList()
            .ForEach(propagator =>
            {
                propagator.Enter += HandleEnter;
                propagator.Exit += HandleExit;
                propagator.Stay += HandleStay;
            });
    }

    private void HandleEnter()
    {
        face.sprite = ouchFace;
    }
    
    private void HandleExit()
    {
        face.sprite = normalFace;
    }

    private void HandleStay()
    {
        face.sprite = touchingFace;
    }

    private void Update()
    {
        bread.color = burnColor.Evaluate(burntness);
    }
}
