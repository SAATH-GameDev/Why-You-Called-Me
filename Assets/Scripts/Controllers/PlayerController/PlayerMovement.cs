using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float walkSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 18f;

    [Space]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Space]
    public AnimationCurve bobbingYCurve;
    public float bobbingYLength = 0.5f;
    public float bobbingYRate = 0.5f;

    [Space]
    public AudioClip walkStep;
    public float walkStepDelay = 0.5f;

    Vector3 velocity;
    bool isGrounded;
    float currentSpeed;

    float bobbingYTimer = 0.0f;
    Transform camTransform;
    Vector3 camBasePosition;

    float walkStepTimer = 0.0f;

    private void Start()
    {
        currentSpeed = walkSpeed;
        camTransform = transform.GetChild(0);
        camBasePosition = camTransform.localPosition;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * walkSpeed * Time.deltaTime);

        float movementProduct = move.sqrMagnitude * walkSpeed * Time.deltaTime;
        bobbingYTimer += bobbingYRate * movementProduct;
        walkStepTimer -= movementProduct;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * sprintSpeed * Time.deltaTime);

            movementProduct = move.sqrMagnitude * sprintSpeed * Time.deltaTime;
            bobbingYTimer += bobbingYRate * movementProduct;
            walkStepTimer -= movementProduct;
        }

        ////

        if(bobbingYTimer > 1.0f)
            bobbingYTimer -= 1.0f;

        camTransform.localPosition = camBasePosition + (Vector3.up * bobbingYCurve.Evaluate(bobbingYTimer) * bobbingYLength);

        if(walkStepTimer <= 0.0f)
        {
            GetComponent<AudioSource>().PlayOneShot(walkStep);
            walkStepTimer += walkStepDelay;
        }
    }
}
