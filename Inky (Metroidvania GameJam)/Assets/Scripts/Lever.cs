using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    public GameObject door;

    private bool canInteract;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            canInteract = false;
        }
    }

    public void pullLever(InputAction.CallbackContext ctx) {
        if(ctx.performed && canInteract && door.activeInHierarchy) {
            door.SetActive(false);
        } else if(ctx.performed && canInteract && !door.activeInHierarchy) {
            door.SetActive(true);
        }
    }
}
