using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;

    void Update()
    {
        transform.position = new Vector2(transform.position.x + cameraSpeed, transform.position.y);
    }
}
