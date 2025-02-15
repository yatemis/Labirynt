using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip newMusic;
    public LevelCompleteText levelCompleteTextScript; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null && newMusic != null)
            {
                audioSource.Stop();
                audioSource.clip = newMusic;
                audioSource.Play();
            }

            if (levelCompleteTextScript != null)
            {
                levelCompleteTextScript.ShowText(); 
            }
        }
    }
}
