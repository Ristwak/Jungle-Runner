using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour
{
    public float moveSpeed = 3.5f;

    private bool attackStarted;
    private bool moveAndAttack;
    private bool attackRight;

    private float attackSpeed = 6f;

    void Start()
    {
        if(transform.position.x > 0f)
        {
            attackRight = false;
        }
        else
        {
            attackRight = true;
        }
    }

    void Update()
    {
        BeeAttack();
    }

    void BeeAttack()
    {
        if(transform.position.y > 0)
        {
            Vector3 temp = transform.position;
            temp.y -= moveSpeed *Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            if(!attackStarted)
            {
                attackStarted = true;

                StartCoroutine(AttackPlayer());
            }
        }

        if(moveAndAttack)
        {
            if(!attackRight)
            {
                transform.position -= Vector3.right * attackSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.right * attackSpeed * Time.deltaTime;
            }
        }
    }

    void Deactivate(){
        gameObject.SetActive(false);
    }
    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(1.5f);

        transform.rotation = Quaternion.Euler(new Vector3(0f,0f,Random.Range(0f, -45f)));

        moveAndAttack = true;
        Invoke("Deactivate",5f);
    }
}
