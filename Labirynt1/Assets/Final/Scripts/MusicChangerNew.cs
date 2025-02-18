using UnityEngine;

public class MusicChangerNew : MonoBehaviour
{
    public AudioClip newMusic;  // Nowa muzyka dla kolejnego poziomu
    private AudioSource audioSource;

    private void Start()
    {
        // Znajdujemy AudioSource w obiekcie z muzyk? w tle
        audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && newMusic != null)
        {
            // Zmieniamy muzyk?
            audioSource.clip = newMusic;
            audioSource.Play();

            // Mo?esz usun?? ten trigger po u?yciu, je?li muzyka ma si? zmienia? tylko raz
            Destroy(gameObject);
        }
    }
}
