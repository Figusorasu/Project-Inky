using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour {

    private PlatformEffector2D effector;
    //public float waitTimeValue;
    //public float waitTime;

    public PlayerController player;

    void Start() {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update() {
        if(/*player.isOnPlatform == true &&*/ Input.GetKey(KeyCode.S)) {
            effector.rotationalOffset = 180f;
        }
        if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W)) {
            effector.rotationalOffset = 0;
        }
        
        #region tutorial
        /*
       if(Input.GetKeyUp(KeyCode.S)) {
            waitTime = waitTimeValue;
       }

       if(Input.GetKey(KeyCode.S)) {
            if(waitTime <= 0) {
                effector.rotationalOffset = 180f;
                waitTime = waitTimeValue;
            } else {
                waitTime -= Time.deltaTime;
            }
       }

       if(Input.GetKey(KeyCode.W)) {
        effector.rotationalOffset = 0;
       }
       */
       #endregion
    }
}
