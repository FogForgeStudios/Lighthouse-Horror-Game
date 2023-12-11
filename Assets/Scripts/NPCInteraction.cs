using UnityEngine;
using System.Collections;

public class NPCInteraction : MonoBehaviour
{
    public bool hasInteracted = false;
    public UIManager uiManager;
    public Animator npcAnimator; // Reference to the Animator component

    void Start()
    {
        // Ensure the NPCAnimator is assigned
        if (npcAnimator == null)
        {
            Debug.LogError("NPCAnimator not assigned in NPCInteraction script.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (hasInteracted)
            return;

        // Display greeting and explanation
        uiManager.DisplayWelcomeMessage();

        // Set a flag to prevent repeated interactions
        hasInteracted = true;

        // Delay the second message after 10 seconds
        StartCoroutine(DisplaySecondMessageAfterDelay(10f));
    }

    IEnumerator DisplaySecondMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Display the second message
        string[] secondMessages = {
        
        };

        uiManager.DisplayMessages(secondMessages);
    }
}
