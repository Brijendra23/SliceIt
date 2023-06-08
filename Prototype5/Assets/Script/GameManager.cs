using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawnObjects = new List<GameObject>();
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    private static int highScore;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomSpawn());
   
        score = 0;
             
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator RandomSpawn()
    {
        while(true)
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
}
