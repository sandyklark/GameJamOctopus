using System;
using System.Linq;
using UnityEngine;

public class BiteTrigger : MonoBehaviour
{
    public Action Triggered;
    
    private void Awake()
    {
        GetComponentsInChildren<Collision2DPropagator>()
            .ToList()
            .ForEach(propagator =>
            {
                propagator.Trigger += OnTrigger;
            });
    }

    private float _lastTriggered;
    private float _triggerThresholdSeconds = 0.5f;
    private void OnTrigger()
    {
        if (Time.realtimeSinceStartup > _lastTriggered + _triggerThresholdSeconds)
        {
            Triggered?.Invoke();
            _lastTriggered = Time.realtimeSinceStartup;
        }
    }
}
