using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed = 5f;
    private bool isPlayerInRange = false;
    private bool isClimbing = false;
    private CharacterController playerController;

    void Start()
    {
        // Assuming your player has a CharacterController component
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleClimbing();
        }

        if (isClimbing)
        {
            ClimbLadder();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (isClimbing)
            {
                ToggleClimbing(); // Stop climbing when the player exits the trigger zone
            }
        }
    }

    void ToggleClimbing()
    {
        isClimbing = !isClimbing;
        if (isClimbing)
        {
            // Disable player's gravity and reset vertical velocity
            playerController.GetComponent<Rigidbody>().useGravity = false;
            playerController.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else
        {
            // Enable player's gravity
            playerController.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void ClimbLadder()
    {
        // Get vertical input for climbing up and down
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate climb direction
        Vector3 climbDirection = new Vector3(0, verticalInput, 0).normalized;

        // Move the player up or down
        playerController.Move(climbDirection * climbSpeed * Time.deltaTime);
    }
}
