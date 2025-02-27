using UnityEngine;
using TMPro; // Upewnij si?, ?e masz TextMeshPro
using System.Collections; // Dodajemy, by dzia?a?y coroutines

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;
    public float mouseSensitivity = 2f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private float xRotation = 0f;
    public Transform cameraTransform;

    // TIMER
    public float levelTime = 600f; // 10 minut = 600 sekund
    private bool timerRunning = false;
    public TextMeshProUGUI timerText; // UI Timer

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Aktualizacja timera
        if (timerRunning)
        {
            levelTime -= Time.deltaTime;
            if (timerText != null)
            {
                int minutes = Mathf.FloorToInt(levelTime / 60);
                int seconds = Mathf.FloorToInt(levelTime % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }

            if (levelTime <= 0)
            {
                TimerExpired();
            }
        }
    }

    // Funkcja uruchamiaj?ca timer po przej?ciu przez ?cian?
    public void StartLevelTimer()
    {
        if (!timerRunning)
        {
            timerRunning = true;
        }
    }

    private void TimerExpired()
    {
        Debug.Log("Czas min??! Game Over!");
        // Mo?esz doda? ekran przegranej lub restart poziomu
    }

    // BOOSTER PR?DKO?CI
    public void ApplySpeedBoost(float boostAmount, float duration)
    {
        StartCoroutine(SpeedBoostCoroutine(boostAmount, duration));
    }

    private IEnumerator SpeedBoostCoroutine(float boostAmount, float duration)
    {
        speed += boostAmount; // Zwi?kszamy pr?dko?? gracza
        yield return new WaitForSeconds(duration); // Czekamy przez czas trwania boosta
        speed -= boostAmount; // Przywracamy oryginaln? pr?dko??
    }
}
