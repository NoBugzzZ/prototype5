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
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0)
        {
            GameOver();
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
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
}
