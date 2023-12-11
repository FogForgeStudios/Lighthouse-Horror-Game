using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPCBehavior : MonoBehaviour
{
    public float walkSpeed = 1.0f;
    private bool isGreeting = false;
    public Text greetingText; // Reference to the UI Text element
    private Animator playerAnimator; // Change to the correct class name

    public Animator PlayerAnimator
    {
        get => playerAnimator;
        set => playerAnimator = value;
    }

    private void Awake()
    {
        // Assuming the NPCBehavior script is on the same GameObject as the Animator component
        playerAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        // Start the GreetAndWalk coroutine when the game begins
        StartCoroutine(GreetAndWalk());

        // Enable and display the UI text
        greetingText.enabled = true;
    }

    IEnumerator GreetAndWalk()
    {
        // Greet the player (You can play an animation, show dialogue, etc.)
        greetingText.text = "Hello there! Welcome to the lighthouse, we have been in need of a new employee since ours has retired, cough...";

        // Trigger the walk animation
        PlayerAnimator.SetTrigger("Walking"); // Adjust the parameter name as needed

        // Start walking slowly
        yield return new WaitForSeconds(1.0f); // Adjust the delay as needed

        // You may want to play a walk animation here
        while (isGreeting)
        {
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
