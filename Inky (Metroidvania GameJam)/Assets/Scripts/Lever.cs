using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    public GameObject door;
    public Animator anim;

    private bool canInteract;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            if(door.activeInHierarchy) {
                anim.SetBool("isLeft", false);
                door.SetActive(false);
                
            } else if(!door.activeInHierarchy) {
                anim.SetBool("isLeft", true);
                door.SetActive(true);
            }
        }
    }
}
