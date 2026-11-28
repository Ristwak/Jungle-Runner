
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    private Text scoreText;
    private int score;
    private bool gameOver;

    public GameObject scorePannel;
    public Text endScore;
    public Animator endPannelAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.LogWarning("Duplicate GameplayController found.", this);
        }
    }

    private void Start()
    {
        GameObject scoreObject = GameObject.Find("ScoreText");

        if (scoreObject != null)
        {
            scoreText = scoreObject.GetComponent<Text>();
        }

        if (scoreText == null)
        {
            Debug.LogError("GameplayController: ScoreText or Text component not found.", this);
        }
        else
        {
            scoreText.text = score.ToString();
        }

        StartCoroutine(CountScore());
    }

    private IEnumerator CountScore()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(0.1f);

            if (gameOver)
                yield break;

            score++;

            if (scoreText != null)
            {
                scoreText.text = score.ToString();
            }
        }
    }

    public void GameOver()
    {
        if (gameOver)
            return;

        gameOver = true;

        if (scorePannel != null)
        {
            scorePannel.SetActive(false);
        }

        if (endScore != null)
        {
            endScore.text = "Height " + score;
        }

        if (endPannelAnim != null)
        {
            endPannelAnim.Play("EndPannel");
        }
        else
        {
            Debug.LogWarning("GameplayController: End panel Animator is not assigned.", this);
        }
    }

    public void Again()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
