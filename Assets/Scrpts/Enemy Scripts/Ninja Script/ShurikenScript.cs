
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    private bool attackRight;
    private float attackSpeed = 6f;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(
            0f,
            0f,
            Random.Range(-45f, 45f)
        );

        attackRight = transform.position.x <= 0f;

        Invoke(nameof(Deactivate), 5f);
    }

    private void Update()
    {
        float direction = attackRight ? 1f : -1f;

        transform.position +=
            Vector3.right * direction * attackSpeed * Time.deltaTime;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
