using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 25; 
    public AudioClip pickupSound; 
    private AudioSource audioSource;

    private void Start()
    {
        
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.Heal(healAmount);

           
            if (pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound);
            }

            
            Destroy(gameObject, 0.2f);
        }
    }
}
