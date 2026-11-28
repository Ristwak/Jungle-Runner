
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BGMover : MonoBehaviour
{
    public float moveSpeed = 5f;

    private GameObject[] sideBounds;
    private float cameraY;
    private float boundHeight;

    public GameObject[] enemies;
    public GameObject[] spawnPositions;

    private void Awake()
    {
        sideBounds = GameObject.FindGameObjectsWithTag("SideBound");

        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            cameraY = mainCamera.transform.position.y - 15f;
        }
        else
        {
            Debug.LogError("BGMover: Main Camera not found.", this);
            enabled = false;
            return;
        }

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boundHeight = boxCollider.bounds.size.y;

        if (sideBounds == null || sideBounds.Length == 0)
        {
            Debug.LogError("BGMover: No objects found with SideBound tag.", this);
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        Move();
        Reposition();
    }

    private void Move()
    {
        Vector3 position = transform.position;
        position.y -= moveSpeed * Time.deltaTime;
        transform.position = position;
    }

    private void Reposition()
    {
        if (transform.position.y >= cameraY)
            return;

        float highestBoundsY = sideBounds[0].transform.position.y;

        for (int i = 1; i < sideBounds.Length; i++)
        {
            if (sideBounds[i] != null &&
                sideBounds[i].transform.position.y > highestBoundsY)
            {
                highestBoundsY = sideBounds[i].transform.position.y;
            }
        }

        Vector3 position = transform.position;
        position.y = highestBoundsY + boundHeight - 1f;
        transform.position = position;

        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (enemies == null || enemies.Length == 0)
            return;

        // Preserve original enemy spawning frequency.
        if (Random.Range(0, 10) <= 0)
            return;

        int randomEnemyIndex = Random.Range(0, enemies.Length);

        if (enemies[randomEnemyIndex] == null)
            return;

        if (randomEnemyIndex == 0)
        {
            // Flag enemy spawns in the middle.
            Instantiate(
                enemies[randomEnemyIndex],
                new Vector3(0f, transform.position.y, 3f),
                Quaternion.identity
            );
        }
        else
        {
            if (spawnPositions == null ||
                spawnPositions.Length < 2 ||
                spawnPositions[0] == null ||
                spawnPositions[1] == null)
            {
                Debug.LogWarning("BGMover: Spawn positions are not assigned.", this);
                return;
            }

            GameObject enemy = Instantiate(enemies[randomEnemyIndex]);
            Vector3 enemyScale = enemy.transform.localScale;

            if (Random.Range(0, 2) > 0)
            {
                enemy.transform.position = spawnPositions[0].transform.position;
                enemyScale.x = -Mathf.Abs(enemyScale.x);
            }
            else
            {
                enemy.transform.position = spawnPositions[1].transform.position;
                enemyScale.x = Mathf.Abs(enemyScale.x);
            }

            enemy.transform.localScale = enemyScale;
        }
    }
}
