using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    
    public int id;

    public Animator anim;
    public Rigidbody2D checkpoint;

    private GameObject[] allCheckpoints;
    private bool canInteract;

    private void Awake() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        if(gm.activeCheckPointId == id) {
            activateCheckpoint();
        }
    }

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
            activateCheckpoint();
        }       
    }

    void activateCheckpoint() {
        allCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        for(int i = 0; i < allCheckpoints.Length; i++) {
            allCheckpoints[i].GetComponent<Animator>().SetBool("isActive", false);
        }
        gm.lastCheckPointPos = transform.position;
        gm.activeCheckPointId = id;
        anim.SetBool("isActive", true);
    }
}
