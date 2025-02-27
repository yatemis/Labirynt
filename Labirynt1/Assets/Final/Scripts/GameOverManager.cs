using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen; // Ekran Game Over (Canvas)
    public GameObject restartButton;  // Przycisk restartu

    void Start()
    {
        gameOverScreen.SetActive(false);
        restartButton.SetActive(false);  // Ukrywa przycisk restartu na starcie
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        restartButton.SetActive(true);  // Pokazuje przycisk restartu
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        restartButton.SetActive(false); // Ukrywa przycisk restartu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}









