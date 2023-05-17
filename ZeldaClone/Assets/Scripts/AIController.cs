using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform component
    public float moveSpeed = 5f;  // Speed at which the AI moves
    public float detectionRadius = 10f;  // Radius within which the AI detects the player
    public float raycastDistance = 2f;  // Distance for raycast detection
    public float fallSpeed = 10f;  // Speed at which the AI falls

    private Vector3 initialPosition;  // Initial position of the AI
    private Animator animator;  // Reference to the Animator component
    private bool isFalling = false;  // Flag indicating if the AI is falling

    private void Start()
    {
        initialPosition = transform.position;  // Store the initial position of the AI
        animator = GetComponent<Animator>();  // Get the Animator component attached to the AI
    }

    private void Update()
    {
        if (player != null)
        {
            // Check if the player is within the detection radius
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= detectionRadius)
            {
                Vector3 direction = player.position - transform.position;
                direction.y = 0f; // Disable vertical movement
                direction.Normalize();  // Normalize the direction to have a magnitude of 1
                // Perform raycast to check for obstacles
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction, out hit, raycastDistance))
                {
                    // If raycast hits a wall, calculate a new direction perpendicular to the hit normal
                    Vector3 hitNormal = hit.normal;
                    direction = Vector3.Reflect(direction, hitNormal);
                }

                transform.position += direction * moveSpeed * Time.deltaTime;

                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

                // Update the animator parameter for movement speed
                animator.SetFloat("Speed", direction.magnitude);

                // Check if the AI is on the ground
                if (!isFalling && !IsGrounded())
                {
                    // Start falling if not already falling
                    isFalling = true;
                    animator.SetBool("IsFalling", true);
                }
            }
            else
            {
                animator.SetFloat("Speed", 0f);
                animator.SetBool("IsFalling", false);
                isFalling = false;
            }
        }
    }

    private bool IsGrounded()
    {
        // Check if the AI is grounded using a raycast
        float raycastDistance = 1f;
        bool isGrounded = Physics.Raycast(transform.position, -Vector3.up, raycastDistance);
        return isGrounded;
    }
}
