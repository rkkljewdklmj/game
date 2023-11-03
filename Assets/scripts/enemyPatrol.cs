using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;
        anim.SetBool("IsRunning", true);
    }

   
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == PointB.transform)
        {
           rb.velocity = new Vector2(speed, 0);
        }
        else
        {
          rb.velocity = new Vector2(-speed, 0);
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {
            flip();
            currentPoint = PointA.transform; 
        }
         if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            flip();
            currentPoint = PointB.transform; 
        }

         void flip()
        {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        }

    }
}
