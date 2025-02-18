using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteTextFinal : MonoBehaviour
{
    public Text levelCompleteText; // Nowy tekst dla nowej ?ciany

    void Start()
    {
        levelCompleteText.gameObject.SetActive(false); // Ukryj tekst na start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Sprawdza, czy to gracz przeszed? przez ?cian?
        {
            levelCompleteText.gameObject.SetActive(true); // Pokazuje tekst
            Invoke("HideText", 3f); // Ukrywa tekst po 3 sekundach
        }
    }

    void HideText()
    {
        levelCompleteText.gameObject.SetActive(false); // Schowanie tekstu
    }
}
