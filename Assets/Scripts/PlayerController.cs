using System;
using System.Numerics;
using UnityEditor.Callbacks;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 velocity;
    public float playerSpeed = 8.0f;
    public float jumpHeight = 10.0f;
    private Animator animator;
    private Vector3 move;
    private bool jump;

    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        // Makes the player jump

        if (jump && IsGrounded()) {
            float gravity = Mathf.Abs(Physics.gravity.y); 
            float jumpForce = rb.mass * (float) Math.Sqrt(2 * gravity * jumpHeight);
            rb.AddForce(-Physics.gravity.normalized * jumpForce, ForceMode.Impulse);
            jump = false;
            animator.SetBool("isJumping", true);
        } 
        
        rb.MovePosition(transform.position + move * Time.fixedDeltaTime * playerSpeed);
    }

    void Update() {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (move != Vector3.zero) {
            animator.SetBool("isSprinting", true);
            gameObject.transform.forward = move;

        } else {
            animator.SetBool("isSprinting", false);
        }

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        } else if (rb.linearVelocity.y == 0 && animator.GetBool("isJumping")) {
            animator.SetBool("isJumping", false);
        }
    }

    bool IsGrounded() {
        float distToGround = GetComponent<Collider>().bounds.extents.y;
        return Physics.Raycast(transform.position + Vector3.up, Vector3.down, 1.1f);
    }
}
