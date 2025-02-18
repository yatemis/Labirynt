using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private Light flashlight;
    private bool isOn = true;

    void Start()
    {
        flashlight = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // W??czenie/wy??czenie latarki
        {
            isOn = !isOn;
            flashlight.enabled = isOn;
        }
    }
}
