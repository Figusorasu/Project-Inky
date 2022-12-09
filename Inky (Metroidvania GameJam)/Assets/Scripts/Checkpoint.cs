using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Checkpoint : MonoBehaviour
{
    public PlayerController player;
    public Animator anim;
    public Rigidbody2D checkpoint;

    private GameObject[] allCheckpoints;
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

    public void Interact(InputAction.CallbackContext ctx) {
        if(ctx.performed && canInteract ) {
            allCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
            
            for(int i = 0; i < allCheckpoints.Length; i++) {
                allCheckpoints[i].GetComponent<Animator>().SetBool("isActive", false);
            }

            anim.SetBool("isActive", true);
            player.respawn_x = checkpoint.position.x;
            player.respawn_y = checkpoint.position.y;
        } 
    }
}
