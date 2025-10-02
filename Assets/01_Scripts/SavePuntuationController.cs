using UnityEngine;
using UnityEngine.UI;

public class SavePuntuationController : MonoBehaviour
{
    [Header("Puntuation Settings")]
    [SerializeField] private int defaultScore = 0;

    [Header("References")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreTextA;
    [SerializeField] private Text scoreTextB;
    [SerializeField] private Text scoreTextMainMenu;

    void Start()
    {
        DisplayHighScore();
        UpdateScoreDisplayA(0);
        UpdateScoreDisplayB(0);
    }
  
    public void SavePuntuation (int pointA, int pointB)
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore", defaultScore);
        int newHighScore = Mathf.Max(currentHighScore, Mathf.Max(pointA, pointB));
        PlayerPrefs.SetInt("HighScore", newHighScore);
        DisplayHighScore();
    }

    public void UpdateScoreDisplayA(int currentA)
    {
        if (scoreTextA != null)
        {
            scoreTextA.text = currentA.ToString();
        }
    }

    public void UpdateScoreDisplayB(int currentB)
    {
        if (scoreTextB != null)
        {
            scoreTextB.text = currentB.ToString();
        }
    }

    void DisplayHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", defaultScore);

        if (scoreTextMainMenu != null)
        {
            scoreTextMainMenu.text = highScore.ToString();
        }
        else if (scoreText != null)
        {
            scoreText.text = highScore.ToString();
        }
    }
}
