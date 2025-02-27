using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public GameOverManager gameOverManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Sprawdza, czy dotkn?? gracz
        {
            gameOverManager.ShowGameOverScreen(); // Pokazuje ekran Game Over
        }
    }
}
