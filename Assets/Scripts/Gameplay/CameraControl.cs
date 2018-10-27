using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraControl : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    public Vector3 offset;
    public float smoothTime = 0.5f;
    public float minZoom = 40.0f, maxZoom = 10.0f;
    public float zoomLimiter = 50.0f;
    public float radius = 35.0f;

    private Vector3 velocity;
    public List<Vector3> lastPosition = new List<Vector3>();
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();    
    }

    void LateUpdate()
    {
        Focus();

        Zoom();

        TargetBoundaries();
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);

        //Debug.Log(GetGreatestDistance());
    }

    private float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int count = 0; count < targets.Count; count++)
        {
            bounds.Encapsulate(targets[count].position);
        }

        return bounds.size.x;
    }

    private void Focus()
    {
        if (targets.Count == 0)
        {
            return;
        }

        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    private Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int count = 0; count < targets.Count; count++)
        {
            bounds.Encapsulate(targets[count].position);
        }

        return bounds.center;
    }

    private void TargetBoundaries()
    {
        lastPosition.Capacity = targets.Count;

        for (int count = 0; count < targets.Count; count++)
        {
            if (Vector3.Distance(targets[count].position, GetCenterPoint()) <= radius)
            {
                lastPosition[count] = targets[count].position;
            }
            else
            {
                targets[count].position = lastPosition[count];
            }
        }
    }
}
