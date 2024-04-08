using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator anim;

    private bool onLeft, onRight;
    private bool jumped;

    [SerializeField]
    AudioSource audioKill, audioJump;

    [SerializeField]
    private AudioClip deadSound;

    private bool isAlive = true;

    void Awake()
    {
        // Instead of adding Jump function on Button's OnClickListner in UNity we are using code and assigning it directly here
        GameObject.Find("JumpBtn").GetComponent<Button>().onClick.AddListener(Jump);
        anim = GetComponent<Animator>();

        onRight = true;
        onLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (!jumped)
            {
                if (onRight)
                {
                    anim.Play("RunRight");
                }
                else
                {
                    anim.Play("RunLeft");
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (onRight)
                {
                    anim.Play("JumpLeft");
                }
                else
                {
                    anim.Play("JumpRight");
                }
                jumped = true;
                audioJump.Play();
            }
        }
    }

    public void Jump()
    {
        if (isAlive)
        {
            if (onRight)
            {
                anim.Play("JumpLeft");
            }
            else
            {
                anim.Play("JumpRight");
            }
            jumped = true;
            audioJump.Play();
        }
    }

    void OnLeft()
    {
        onLeft = true;
        onRight = false;

        jumped = false;
    }

    // We have played the event in start on JumpRight animation because we are assigning it the same animation as JumpLeft and then we are playing the animation in reverse by adding (-)sign
    void OnRight()
    {
        onLeft = false;
        onRight = true;

        jumped = false;
    }

    void PlayerDied()
    {
        audioKill.clip = deadSound;
        audioKill.Play();

        isAlive = false;

        if(transform.position.x > 0f)
        {
            anim.Play("PlayerDiedRight");
        }
        else
        {
            anim.Play("PlayerDiedLeft");
        }

        GameplayController.instance.GameOver();
        Time.timeScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(jumped)
        {
            if(target.tag == "Enemy")
            {
                target.gameObject.SetActive(false);
                audioKill.Play();
            }
        }
        else
        {
            if(target.tag == "Enemy")
            {
                PlayerDied();
            }
        }

        if(target.tag == "EnemyTree")
        {
            PlayerDied();
        }
    }
}
