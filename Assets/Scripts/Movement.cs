using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 10f;
    public float maxSpeed = 15f;
    public float jumpForce = 5f;

    [Header("Visual Roll")]
    public Transform ballMesh;   // drag the child sphere here
    public float rollMultiplier = 1f;


    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ground check
        if (groundCheck != null)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        }

        // Jump
        if (InputSystem.actions.FindAction("Jump").WasPressedThisFrame() && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Get input
        Vector2 input = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();
        float h = input.x; // A/D
        float v = input.y;   // W/S

        Vector3 movement = new Vector3(h, 0f, v);

        // Optional: cap horizontal speed
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (flatVel.magnitude < maxSpeed)
        {
            rb.AddForce(movement * moveForce, ForceMode.Force);
        }

         Vector3 velocity = rb.linearVelocity;
        Vector3 axis = Vector3.Cross(Vector3.up, velocity);
        float speed = velocity.magnitude;
        if (speed > 0.01f)
        {
            float angle = speed / GetComponent<SphereCollider>().radius * Mathf.Rad2Deg * rollMultiplier;
            ballMesh.Rotate(axis.normalized, angle * Time.fixedDeltaTime, Space.World);
        }
    }
}