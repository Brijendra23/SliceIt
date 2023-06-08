
using UnityEngine;
using UnityEngine.UI;

public class Difficultybutton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button=GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

   
    private void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
