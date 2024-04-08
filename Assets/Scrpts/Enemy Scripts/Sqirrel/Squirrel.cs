using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    private float moveSpeed = 3f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += moveSpeed *Time.deltaTime;
        transform.position = temp;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "SideBound")
        {
            moveSpeed *= -1;

            Vector3 temp = transform.localScale;
            temp.x *= -1f;
            transform.localScale = temp;
        }
    }
}