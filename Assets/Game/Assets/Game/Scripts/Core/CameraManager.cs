using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Player player => Player.instance;

    public float cameraSpeed = 1;

    Vector3 velocity;

    private void Start()
    {
        transform.position = player.transform.position;
    }

    private void LateUpdate()
    {
        if (!player) return;

        Vector3 targetPosition = player.transform.position;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition + velocity / 2, ref velocity, cameraSpeed);
    }

}
