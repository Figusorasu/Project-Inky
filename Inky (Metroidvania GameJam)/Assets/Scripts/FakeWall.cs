using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWall : MonoBehaviour {

    public GameObject wall;
    private GameObject[] lanterns;

    private void Start() {
        lanterns = GameObject.FindGameObjectsWithTag("HiddenLanterns");
        turnOffLanterns();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            wall.SetActive(false);
            turnOnLanterns();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            wall.SetActive(true);
            turnOffLanterns();
        }
    }

    private void turnOffLanterns() {
        for(int i = 0; i < lanterns.Length; i++) {
            lanterns[i].GetComponent<Animator>().SetBool("isOff", true);
        }
    }

    private void turnOnLanterns() {
        for(int i = 0; i < lanterns.Length; i++) {
            lanterns[i].GetComponent<Animator>().SetBool("isOff", false);
        }
    }

}
