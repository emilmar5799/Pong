using UnityEngine;
using UnityEngine.UI;

public class SavePuntuationController : MonoBehaviour
{
    [Header("Scores")]
    [SerializeField] private int scoreA = 0; // Jugador Izquierdo
    [SerializeField] private int scoreB = 0; // Jugador Derecho

    [Header("References")]
    [SerializeField] private Text scoreTextA; // UI Jugador A
    [SerializeField] private Text scoreTextB; // UI Jugador B
    [SerializeField] private Text scoreTextMainMenu; // HighScore en menú

    void Start()
    {
        DisplayScores();
        DisplayHighScore();
    }

    public void AddPoint(bool isLeftWall)
    {
        // Si la bola chocó contra la pared izquierda -> punto para jugador derecho
        if (isLeftWall)
        {
            scoreB++;
        }
        else
        {
            scoreA++;
        }

        // Guardar highscore
        SavePuntuation(scoreA, scoreB);

        // Actualizar UI
        DisplayScores();
    }

    public void SavePuntuation(int pointA, int pointB)
    {
        int currentHigh = PlayerPrefs.GetInt("HighScore", 0);

        if (pointA > currentHigh)
        {
            PlayerPrefs.SetInt("HighScore", pointA);
        }
        else if (pointB > currentHigh)
        {
            PlayerPrefs.SetInt("HighScore", pointB);
        }
    }

    void DisplayScores()
    {
        if (scoreTextA != null) scoreTextA.text = scoreA.ToString();
        if (scoreTextB != null) scoreTextB.text = scoreB.ToString();
    }

    void DisplayHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (scoreTextMainMenu != null)
        {
            scoreTextMainMenu.text = highScore.ToString();
        }
    }
}
