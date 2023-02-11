using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followcam : MonoBehaviour
{
    public float leftLimit = 8;
    public float rightLimit = 16;
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    public float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] public Transform target;

    public float bottomLimit;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
        // Limit the camera's x-axis movement based on the position of the boundary objects
        
        newPosition.x = Mathf.Clamp(newPosition.x, leftLimit, rightLimit);

        // Limit the camera's y-axis movement based on the bottom limit
        newPosition.y = Mathf.Max(newPosition.y, bottomLimit);

        transform.position = newPosition;
    }
}
