
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 1f;

    private float cameraY;

    private void Start()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            cameraY = mainCamera.transform.position.y - 10f;
        }
        else
        {
            Debug.LogError("EnemyMove: Main Camera not found.", this);
            enabled = false;
        }
    }

    private void Update()
    {
        Move();
        Deactivate();
    }

    private void Move()
    {
        Vector3 position = transform.position;
        position.y -= moveSpeed * Time.deltaTime;
        transform.position = position;
    }

    private void Deactivate()
    {
        if (transform.position.y < cameraY)
        {
            gameObject.SetActive(false);
        }
    }
}
