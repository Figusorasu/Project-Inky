using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDubbleJump : MonoBehaviour
{
    private GameMaster gm;

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        if(gm.DubbleJumpUnlocked) {
            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            gm.DubbleJumpUnlocked = true;
        }

        Destroy(this);
    }
}
