using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultiPlayerCamera : MonoBehaviour {

    public List<Transform> player;

    public Vector3 offset;

    public float smoothTime = .5f;

    public float minZoom = 40f;

    public float maxZoom = 10f;

    public float zoomLimiter = 50f;

    private Vector3 velocity;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if(player.Count == 0)
        {
            return;
        }

        Move();
        Zoom();
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(player[0].position, Vector3.zero);
        for (int i = 0; i < player.Count; i++)
        {
            bounds.Encapsulate(player[i].position);
        }

        return bounds.size.z;
    }

    Vector3 GetCenterPoint()
    {
        if(player.Count == 1)
        {
            return player[0].position;
        }

        var bounds = new Bounds(player[0].position, Vector3.zero);

        for(int i = 0; i < player.Count; i++)
        {
            bounds.Encapsulate(player[i].position);

        }

        return bounds.center;
    }
}
