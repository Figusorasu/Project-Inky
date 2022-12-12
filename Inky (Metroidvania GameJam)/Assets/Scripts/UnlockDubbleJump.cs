using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDubbleJump : MonoBehaviour
{
    private GameMaster gm;

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
}
