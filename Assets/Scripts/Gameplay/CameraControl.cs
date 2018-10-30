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

    void Update()
    {
        FindTargets();
    }

    void LateUpdate()
    {
        Focus();

        Zoom();

        TargetBoundaries();
    }

    private void FindTargets()
    {
        var targetsFound = FindObjectsOfType<MultiplayerMovement>();    // Replace with PlayerController script of some kind

        for(int count = 0; count < targetsFound.Length; count++)
        {
            if (!targets.Contains(targetsFound[count].transform))
            {
                targets.Add(targetsFound[count].transform);
                lastPosition.Add(Vector3.zero);
            }
            else
            {
                GameObject target = targets[count].gameObject;

                if (target.GetComponent<MultiplayerMovement>().health <= 0)     // This can be used to check health from player (checking if gameobject is not active does not work)
                {
                    //Debug.Log(target.activeSelf);
                    targets.Remove(targets[count].transform);
                    lastPosition.RemoveAt(count);
                    target.SetActive(false);                                    // This can be rid of when player controller turns off player gameobject
                    //Debug.Log(target.activeSelf);
                }
            }
        }
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
