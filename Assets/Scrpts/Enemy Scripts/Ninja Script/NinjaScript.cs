
using UnityEngine;

public class NinjaScript : MonoBehaviour
{
    public GameObject shuriken;

    private float moveSpeed = 5f;
    private float cameraY;
    private bool attackedPlayer;

    private void Start()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            cameraY = mainCamera.transform.position.y - 10f;
        }
        else
        {
            Debug.LogError("NinjaScript: Main Camera not found.", this);
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

        if (position.y < 0f && !attackedPlayer)
        {
            attackedPlayer = true;

            if (shuriken != null)
            {
                Instantiate(shuriken, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("NinjaScript: Shuriken prefab is not assigned.", this);
            }
        }
    }

    private void Deactivate()
    {
        if (transform.position.y < cameraY)
        {
            gameObject.SetActive(false);
        }
    }
}
