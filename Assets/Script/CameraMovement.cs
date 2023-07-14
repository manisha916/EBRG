using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float smoothTime = 0.25f;
    Vector3 currentVelocity;

     Vector3 camPos;
    public void Start()
    {
        camPos = transform.position;
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            target.position + offset,
            ref currentVelocity,
            smoothTime
            );
    }

    public void ResetCamera()
    {
        transform.position = camPos;
    }
}