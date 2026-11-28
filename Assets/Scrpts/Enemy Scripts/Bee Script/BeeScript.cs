
using System.Collections;
using UnityEngine;

public class BeeScript : MonoBehaviour
{
    public float moveSpeed = 3.5f;

    private bool attackStarted;
    private bool moveAndAttack;
    private bool attackRight;

    private float attackSpeed = 6f;

    private void Start()
    {
        attackRight = transform.position.x <= 0f;
    }

    private void Update()
    {
        BeeAttack();
    }

    private void BeeAttack()
    {
        if (transform.position.y > 0f)
        {
            Vector3 position = transform.position;
            position.y -= moveSpeed * Time.deltaTime;
            transform.position = position;
        }
        else if (!attackStarted)
        {
            attackStarted = true;
            StartCoroutine(AttackPlayer());
        }

        if (moveAndAttack)
        {
            float direction = attackRight ? 1f : -1f;
            transform.position += Vector3.right * direction * attackSpeed * Time.deltaTime;
        }
    }

    private IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(1.5f);

        transform.rotation = Quaternion.Euler(
            0f,
            0f,
            Random.Range(0f, -45f)
        );

        moveAndAttack = true;
        Invoke(nameof(Deactivate), 5f);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
