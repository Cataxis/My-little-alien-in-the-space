using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float initialCameraSpeed;
    [SerializeField] private float cameraAcceleration;
    private float currentCameraSpeed;

    void Start()
    {
        currentCameraSpeed = initialCameraSpeed;
    }

    void Update()
    {
        float moveDistance = currentCameraSpeed * Time.deltaTime;
        transform.position += new Vector3(moveDistance, 0, 0);

        // Aumentar la velocidad de la cámara de forma progresiva
        currentCameraSpeed += cameraAcceleration * Time.deltaTime;
    }
}

