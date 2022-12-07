using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTP : MonoBehaviour
{
    public GameObject player;
    public GameObject destination;

    private float des_x;
    private float des_y;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            des_x = destination.GetComponent<Rigidbody2D>().position.x;
            des_y = destination.GetComponent<Rigidbody2D>().position.y;
            player.GetComponent<Rigidbody2D>().position = new Vector2(des_x, des_y);
        }
    }
}
