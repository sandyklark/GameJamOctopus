using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target1;
    public Transform target2;

    public float smoothTime = 0.5f;
    public float minSize = 3f;
    public float maxSize = 15f;
    public float sizeLimiter = 50f;

    private Vector3 velocity;
    private Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (target1 && target2)
        {
            Vector3 midpoint = (target1.position + target2.position) / 2f;
             
            float distance = Vector3.Distance(target1.position, target2.position);
            float newSize = Mathf.Lerp(minSize,maxSize , distance / sizeLimiter);
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, newSize, Time.deltaTime);
            midpoint.z = -10;
            transform.position = Vector3.SmoothDamp(transform.position, midpoint, ref velocity, smoothTime);
        }
    }
}
