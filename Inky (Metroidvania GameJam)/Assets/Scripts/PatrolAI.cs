using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public float speed;
    public float rayLenght;
    public Transform groundDetection;
    public LayerMask whatIsGround;

    public Transform wallDetection;
    private bool hitWall;

    private bool movingRight = true;
    private RaycastHit2D groundInfo;

    void Update() {

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayLenght, whatIsGround);
        hitWall = Physics2D.OverlapCircle(wallDetection.position, 0.5f, whatIsGround);


        if((groundInfo.collider == true && hitWall) || (groundInfo.collider == false && !hitWall)) {
            flip();
        }
    }

    private void flip() {
        if(movingRight) {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        } else {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }
}
