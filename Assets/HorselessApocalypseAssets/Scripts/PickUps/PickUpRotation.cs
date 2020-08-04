using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRotation : MonoBehaviour
{
    public float rotationSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        float y = transform.eulerAngles.y;
        y += (Time.deltaTime * rotationSpeed);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, y, transform.eulerAngles.z);
    }
}
