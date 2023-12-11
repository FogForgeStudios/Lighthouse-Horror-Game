using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light flashlight;
    private bool isFlashlightOn = false;

    void Start()
    {
        if (flashlight == null)
        {
            // Assuming the flashlight is a child of the GameObject this script is attached to
            flashlight = transform.Find("Flashlight").GetComponent<Light>();
        }

        // Turn off the flashlight at the start
        ToggleFlashlight(false);
    }

    void Update()
    {
        // Toggle the flashlight on/off when the player presses a key (you can customize the key)
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashlightOn = !isFlashlightOn;
            ToggleFlashlight(isFlashlightOn);
        }
    }

    void ToggleFlashlight(bool state)
    {
        flashlight.enabled = state;
    }
}
