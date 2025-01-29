using UnityEngine;
using TMPro;  // Dodaj to, ?eby u?ywa? TextMeshPro

public class LevelCompleteText : MonoBehaviour
{
    private TextMeshProUGUI levelCompleteText; // Komponent TextMeshProUGUI
    private float displayTime = 3f;

    void Start()
    {
        // U?ywamy GetComponent do pobrania komponentu TextMeshProUGUI
        levelCompleteText = GetComponentInChildren<TextMeshProUGUI>();  // Pobierz komponent TextMeshProUGUI z dziecka

        if (levelCompleteText == null)
        {
            Debug.LogError("Komponent TextMeshProUGUI nie zosta? znaleziony na obiekcie!");
        }
        else
        {
            levelCompleteText.enabled = false; // Ukrywamy tekst na pocz?tku
        }
    }

    public void ShowText()
    {
        if (levelCompleteText != null)
        {
            levelCompleteText.enabled = true; // Pokazuje tekst
            Invoke("HideText", displayTime);  // Ukrywa tekst po okre?lonym czasie
        }
    }

    void HideText()
    {
        if (levelCompleteText != null)
        {
            levelCompleteText.enabled = false; // Ukrywa tekst
        }
    }
}
