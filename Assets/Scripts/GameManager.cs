using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabs;
    private TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive = false;
    private int difficulty;
    public int throwSpeed = 3;
    private int lives = 3;
    private TextMeshProUGUI livesText;
    private Slider volumn;
    private bool isPause = false;
    private GameObject mask;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        score = 0;
        scoreText.text = "Score: " + score;
        //gameOverText = GameObject.Find("Game Over").GetComponent<TextMeshProUGUI>();
        //restartButton = GameObject.Find("Restart").GetComponent<Button>();

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        livesText = GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
        volumn = GameObject.Find("Volumn").GetComponentInChildren<Slider>();
        mask = GameObject.Find("Mask");
        mask.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPause = !isPause;
            if (isPause)
            {
                GamePause();
            }
            else
            {
                GameResume();
            }
        }
    }

    public void SetVolumn(float volumn)
    {
        Debug.Log(volumn);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void MinusLives(int livesToMinus)
    {
        lives -= livesToMinus;
        livesText.text = "Lives: " + lives;
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            int index = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[index]);
            yield return new WaitForSeconds(throwSpeed);
        }
    }

    private void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameStart(int d)
    {
        isGameActive = true;
        throwSpeed /= d;
        StartCoroutine(SpawnTargets());
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        mask.SetActive(true);
    }

    public void GameResume()
    {
        Time.timeScale = 1;
        mask.SetActive(false);
    }
}
