    using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls controls;
    private Vector2 moveInput;
    private Rigidbody rb;

    [Header("Player Move Settings")]
    public float walkSpeed = 5f;
    public float RunSpeed = 10f;
    public float JumpForce = 5f;

    private bool isGround = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerControls();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Jump.performed += ctx => Onjump();
        controls.Player.Run.performed += ctx => OnRun();
    }
    void Update()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + GetmoveInput());
    }
    Vector3 GetmoveInput()
    {
        return ((transform.forward * moveInput.y) + (transform.right * moveInput.x)) * walkSpeed * Time.fixedDeltaTime;
    }

    void OnEnable()
    {
        controls.Enable();
    }
    void OnDisable()
    {
        controls.Disable();
    }
    void Onjump()
    {
        Debug.Log("점프 입력값 받음");
        if (isGround == true)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        // 점프할때 빡! 하고 힘을 줌
    }
    void OnRun()
    {
        Debug.Log("달리기 입력값 받음");
    }
}
