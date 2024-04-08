using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    private float cameraY;

    void Start()
    {
        cameraY = Camera.main.transform.position.y -10f;
    }


    void Update()
    {
        Move();
        Deactivate();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= moveSpeed *Time.deltaTime;
        transform.position = temp;
    }

    void Deactivate()
    {
        if(transform.position.y <cameraY)
        {
            gameObject.SetActive(false);
        }
    }
}
