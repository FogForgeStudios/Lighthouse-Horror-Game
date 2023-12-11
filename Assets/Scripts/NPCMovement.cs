using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 3.0f; // Adjust this to set the speed of the NPC
    private CharacterController characterController;
    private Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();

        // Set animation parameters based on movement
        UpdateAnimationParameters();
    }

    void Move()
    {
        // Move the NPC forward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        characterController.SimpleMove(forward * speed);
    }

    void UpdateAnimationParameters()
    {
        // Set the "IsWalking" parameter in the Animator based on movement speed
        float moveSpeed = characterController.velocity.magnitude;
        animator.SetBool("IsWalking", moveSpeed > 0.1f);
    }
}
