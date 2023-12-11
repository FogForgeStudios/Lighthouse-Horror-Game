using UnityEngine;

public class AttachFlashlight : MonoBehaviour
{
    public GameObject character;    // Reference to your character GameObject
    public GameObject hand;         // Reference to your character's hand GameObject
    public GameObject flashlight;   // Reference to your flashlight GameObject

    void Start()
    {
        if (character == null || hand == null || flashlight == null)
        {
            Debug.LogError("Character, hand, or flashlight references not set!");
            return;
        }

        // Attach the flashlight to the hand at the desired position
        AttachFlashlightToHand();
    }

    void Update()
    {
        // Check for user input (e.g., pressing a key) to toggle the flashlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Toggle the flashlight on/off
            ToggleFlashlight();
        }
    }

    void AttachFlashlightToHand()
    {
        // Assuming the flashlight is a child of the character's hand
        flashlight.transform.parent = hand.transform;

        // Adjust the position and rotation of the flashlight relative to the hand
        flashlight.transform.localPosition = new Vector3(0.0613f, -0.1007f, -0.0192f); // Adjust as needed
        flashlight.transform.localRotation = Quaternion.Euler(40.315f, -159.273f, -54.813f);  // Adjust as needed

        // Enable the flashlight
        flashlight.SetActive(true);

        // Debug log for attaching flashlight
        Debug.Log("Flashlight attached to hand");
    }

    void ToggleFlashlight()
    {
        // Toggle the state of the flashlight
        flashlight.SetActive(!flashlight.activeSelf);

        // Debug log for toggling flashlight
        Debug.Log("Flashlight toggled. Is active: " + flashlight.activeSelf);
    }
}
