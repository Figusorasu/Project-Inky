using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRegion : MonoBehaviour
{   
    public CameraController cam;

    public Vector2 camMaxPos;
    public Vector2 camMinPos;

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            cam.maxPosition = camMaxPos;
            cam.minPosition = camMinPos;
        }
    }
    
    
}
