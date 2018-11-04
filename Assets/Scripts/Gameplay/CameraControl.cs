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

    private Vector3 velocity;
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
    }

    private void FindTargets()
    {
        var targetsFound = FindObjectsOfType<MultiplayerMovement>();    // Replace with PlayerController script of some kind

        for(int count = 0; count < targetsFound.Length; count++)
        {
            if (!targets.Contains(targetsFound[count].transform))
            {
                targets.Add(targetsFound[count].transform);
            }
            else
            {
                GameObject target = targets[count].gameObject;

                if (target.GetComponent<MultiplayerMovement>().health <= 0)     // This can be used to check health from player (checking if gameobject is not active does not work)
                {
                    //Debug.Log(target.activeSelf);
                    targets.Remove(targets[count].transform);
                    target.SetActive(false);                                    // This can be rid of when player controller turns off player gameobject
                    //Debug.Log(target.activeSelf);
                }
            }
        }
    }

    private void Zoom()
    {
        float newZoomX = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistanceX() / zoomLimiter);
        float newZoomZ = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistanceZ() / zoomLimiter);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoomX, Time.deltaTime);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoomZ, Time.deltaTime);

        //Debug.Log(GetGreatestDistance());
    }

    private float GetGreatestDistanceX()
    {
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int count = 0; count < targets.Count; count++)
        {
            bounds.Encapsulate(targets[count].position);
        }

        return bounds.size.x;
    }

    private float GetGreatestDistanceZ()
    {
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int count = 0; count < targets.Count; count++)
        {
            bounds.Encapsulate(targets[count].position);
        }

        return bounds.size.z;
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

    public Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int count = 0; count < targets.Count; count++)
        {
            bounds.Encapsulate(targets[count].position);
        }

        return bounds.center;
    }
}
