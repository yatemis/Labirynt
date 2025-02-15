using UnityEngine;
using TMPro; 

public class LevelCompleteText : MonoBehaviour
{
    private TextMeshProUGUI levelCompleteText; 
    private float displayTime = 3f;

    void Start()
    {
      
        levelCompleteText = GetComponentInChildren<TextMeshProUGUI>();  

        if (levelCompleteText == null)
        {
            Debug.LogError("Komponent TextMeshProUGUI nie zostal znaleziony na obiekcie!");
        }
        else
        {
            levelCompleteText.enabled = false;
        }
    }

    public void ShowText()
    {
        if (levelCompleteText != null)
        {
            levelCompleteText.enabled = true; 
            Invoke("HideText", displayTime);  
        }
    }

    void HideText()
    {
        if (levelCompleteText != null)
        {
            levelCompleteText.enabled = false; 
        }
    }
}
