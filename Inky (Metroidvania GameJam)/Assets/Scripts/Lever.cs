using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    public GameObject door;
    public Animator anim;
    public GameObject info;

    private bool canInteract;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            canInteract = true;
            info.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            canInteract = false;
            info.SetActive(false);
        }
    }

    public void pullLever(InputAction.CallbackContext ctx) {
        if(ctx.performed && canInteract && door.activeInHierarchy) {
            anim.SetBool("isLeft", false);
            door.SetActive(false);
            
        } else if(ctx.performed && canInteract && !door.activeInHierarchy) {
            anim.SetBool("isLeft", true);
            door.SetActive(true);
        }
    }
}
