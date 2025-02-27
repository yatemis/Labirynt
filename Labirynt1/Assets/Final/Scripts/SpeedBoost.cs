using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostAmount = 3f; // Jak bardzo zwi?ksza pr?dko??
    public float boostDuration = 10f; // Na ile sekund

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null)
        {
            player.ApplySpeedBoost(boostAmount, boostDuration); // Wywo?anie metody ze zwi?kszeniem pr?dko?ci
            Destroy(gameObject); // Usuni?cie boostera po zebraniu
        }
    }
}

