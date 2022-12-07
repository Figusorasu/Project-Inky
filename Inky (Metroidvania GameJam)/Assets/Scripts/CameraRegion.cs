using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRegion : MonoBehaviour
{   
    public CameraController cam;

    public Vector2 camMaxPos;
    public Vector2 camMinPos;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Debug.Log("CamPos: "+ camMaxPos + ", " + camMinPos);
            cam.maxPosition = camMaxPos;
            cam.minPosition = camMinPos;
            Debug.Log("Pozycja zmieniona");
        }
    }
    
    
}
