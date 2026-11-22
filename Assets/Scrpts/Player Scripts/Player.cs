
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator anim;

    private bool onLeft, onRight;
    private bool jumped;

    [SerializeField]
    private AudioSource audioKill, audioJump;

    [SerializeField]
    private AudioClip deadSound;

    private bool isAlive = true;

    private void Awake()
    {
        GameObject jumpButtonObject = GameObject.Find("JumpBtn");

        if (jumpButtonObject != null)
        {
            Button jumpButton = jumpButtonObject.GetComponent<Button>();

            if (jumpButton != null)
            {
                jumpButton.onClick.AddListener(Jump);
            }
            else
            {
                Debug.LogError("Player: JumpBtn has no Button component.", this);
            }
        }
        else
        {
            Debug.LogError("Player: JumpBtn was not found.", this);
        }

        anim = GetComponent<Animator>();

        onRight = true;
        onLeft = false;

        if (anim == null)
        {
            Debug.LogError("Player: Animator component not found.", this);
        }
    }

    private void Update()
    {
        if (!isAlive || anim == null)
            return;

        if (!jumped)
        {
            if (onRight)
                anim.Play("RunRight");
            else
                anim.Play("RunLeft");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (!isAlive || anim == null)
            return;

        if (onRight)
            anim.Play("JumpLeft");
        else
            anim.Play("JumpRight");

        jumped = true;

        if (audioJump != null)
        {
            audioJump.Play();
        }
    }

    private void OnLeft()
    {
        onLeft = true;
        onRight = false;
        jumped = false;
    }

    private void OnRight()
    {
        onLeft = false;
        onRight = true;
        jumped = false;
    }

    private void PlayerDied()
    {
        if (!isAlive)
            return;

        isAlive = false;

        if (audioKill != null && deadSound != null)
        {
            audioKill.clip = deadSound;
            audioKill.Play();
        }

        if (anim != null)
        {
            if (transform.position.x > 0f)
                anim.Play("PlayerDiedRight");
            else
                anim.Play("PlayerDiedLeft");
        }

        if (GameplayController.instance != null)
        {
            GameplayController.instance.GameOver();
        }
        else
        {
            Debug.LogError("Player: GameplayController instance not found.", this);
        }

        Time.timeScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (!isAlive || target == null)
            return;

        if (target.CompareTag("Enemy"))
        {
            if (jumped)
            {
                target.gameObject.SetActive(false);

                if (audioKill != null)
                {
                    audioKill.Play();
                }
            }
            else
            {
                PlayerDied();
            }
        }

        if (target.CompareTag("EnemyTree"))
        {
            PlayerDied();
        }
    }

    private void OnDestroy()
    {
        GameObject jumpButtonObject = GameObject.Find("JumpBtn");

        if (jumpButtonObject != null)
        {
            Button jumpButton = jumpButtonObject.GetComponent<Button>();

            if (jumpButton != null)
            {
                jumpButton.onClick.RemoveListener(Jump);
            }
        }
    }
}
