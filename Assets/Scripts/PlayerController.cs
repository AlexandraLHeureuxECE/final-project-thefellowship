using UnityEngine;

public class PlayerController : MonoBehaviour {
    private CharacterController controller;
    private Vector3 velocity;
    private float playerSpeed = 8.0f;
    private float jumpHeight = 100.0f;
    private float gravityValue = -6f;
    private Animator animator;

    private void Start() {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (controller.isGrounded && velocity.y < 0) {
            velocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero) {
            gameObject.transform.forward = move;
            animator.Play("Sprint");
        }

        // Makes the player jump
        if (Input.GetButtonDown("Jump") && controller.isGrounded) {
            velocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
