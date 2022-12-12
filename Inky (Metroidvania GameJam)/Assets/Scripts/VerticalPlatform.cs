using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VerticalPlatform : MonoBehaviour {

    private PlatformEffector2D effector;
    public PlayerController player;

    void Start() {
        effector = GetComponent<PlatformEffector2D>();
    }

    public void fallFromPlatform(InputAction.CallbackContext ctx) {
        if(player.isOnPlatform == true && ctx.performed) {
            Debug.Log("dupa");
            effector.rotationalOffset = 180f;
            Debug.Log("dupa2");
        }
        if(ctx.canceled) {
            effector.rotationalOffset = 0;
        }
    }

}
