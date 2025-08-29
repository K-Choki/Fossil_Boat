using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private PlayerControls controls;
    private Vector2 LookInput;

    public Transform player;
    public float MouseSensitivity = 100f;
    private float CameraClamp = 85f; // 카메라 상하 각도 제한
    private float xRotation = 0f;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Player.Look.performed += ctx => LookInput = ctx.ReadValue<Vector2>();
        controls.Player.Look.canceled += ctx => LookInput = Vector2.zero;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 커서를 화면 중앙에 고정
        //Cursor.visible = false; // 커서 숨김
    }
    void OnEnable()
    {
        controls.Enable();
    }
    void OnDisable()
    {
        controls.Disable();
    }
    void Update()
    {
        OnLook();
    }
    void OnLook()
    {
        float mouseX = LookInput.x * MouseSensitivity * Time.deltaTime;
        float mouseY = LookInput.y * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -CameraClamp, CameraClamp);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
