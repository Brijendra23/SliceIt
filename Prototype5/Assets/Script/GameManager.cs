using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawnObjects = new List<GameObject>();
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    public Button restartButton;
    public TextMeshProUGUI highScoreText;
    private static int highScore;
    private int score;
    public bool isGameActive;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator RandomSpawn()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index=Random.Range(0, spawnObjects.Count);
            Instantiate(spawnObjects[index]);
            
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }
    public void  GameOver()
    {
        if(score > highScore)
        {
            highScore = score;
        }
        restartButton.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false) ;
        highScoreText.text = highScore.ToString("0");
        isGameActive = true;
        spawnRate /=difficulty;
        score = 0;
        StartCoroutine(RandomSpawn());
        UpdateScore(0);

    }
}
