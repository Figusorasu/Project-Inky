using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    //public Animator anim;

    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -10);
        //anim.GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);


            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
        
    }
    /*
    public void BeginKick()
    {
        anim.SetBool("KickGo", true);
        StartCoroutine(KickCo());
    }
        public IEnumerator KickCo()
    {
        yield return null;
        anim.SetBool("KickGo", false);
    }*/
}