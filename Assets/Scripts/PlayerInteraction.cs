using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    void Update()
    {
        // Check for player input or other conditions to trigger interaction
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        // Raycast forward to check for NPCs in front of the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            // Check if the hit object has the "NPC" tag
            if (hit.collider.CompareTag("NPC"))
            {
                // Call the Interact method on the NPC
                hit.collider.GetComponent<NPCInteraction>().Interact();
            }
        }
    }
}
