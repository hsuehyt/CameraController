using UnityEngine;
using UnityEngine.InputSystem; // New Input System

public class CameraController : MonoBehaviour
{
    [Header("Speeds")]
    public float panSpeed = 0.5f;
    public float zoomSpeed = 0.2f;   // smoother zoom control
    public float rotationSpeed = 5f;

    [Header("Defaults (auto-filled on Start)")]
    public Vector3 defaultPosition;
    public Quaternion defaultRotation;

    [Header("Scene References")]
    [SerializeField] private GameObject POV;          // Point of View (optional helper)
    [SerializeField] private GameObject focalPoint;   // Orbit target
    [SerializeField] private Camera cameraObject;     // Actual camera

    // --- New Input System actions ---
    private InputAction altKey;
    private InputAction resetKey;       // 'F' to reset
    private InputAction mouseDelta;     // <Mouse>/delta
    private InputAction mouseLeft;
    private InputAction mouseMiddle;
    private InputAction mouseRight;

    void Awake()
    {
        // Define actions with sensible default bindings
        altKey       = new InputAction("Alt",       binding: "<Keyboard>/leftAlt");
        resetKey     = new InputAction("Reset",     binding: "<Keyboard>/f");
        mouseDelta   = new InputAction("MouseDrag", binding: "<Mouse>/delta");
        mouseLeft    = new InputAction("LMB",       binding: "<Mouse>/leftButton");
        mouseMiddle  = new InputAction("MMB",       binding: "<Mouse>/middleButton");
        mouseRight   = new InputAction("RMB",       binding: "<Mouse>/rightButton");
    }

    void OnEnable()
    {
        altKey.Enable();
        resetKey.Enable();
        mouseDelta.Enable();
        mouseLeft.Enable();
        mouseMiddle.Enable();
        mouseRight.Enable();
    }

    void OnDisable()
    {
        altKey.Disable();
        resetKey.Disable();
        mouseDelta.Disable();
        mouseLeft.Disable();
        mouseMiddle.Disable();
        mouseRight.Disable();
    }

    void Start()
    {
        // Find references if not set in Inspector
        if (POV == null)       POV = GameObject.Find("POV");
        if (focalPoint == null) focalPoint = GameObject.Find("Focal Point");
        if (cameraObject == null) cameraObject = Camera.main;

        SetDefaults();
    }

    void Update()
    {
        if (altKey.IsPressed())
        {
            HandleMouseInput();
        }

        if (resetKey.WasPressedThisFrame())
        {
            ResetCamera();
        }
    }

    void HandleMouseInput()
    {
        if (cameraObject == null) return;

        // Mouse delta each frame (pixels moved since last frame)
        Vector2 delta = mouseDelta.ReadValue<Vector2>();

        // Right Mouse Button: Zoom (invert Y like original)
        if (mouseRight.IsPressed())
        {
            float zoomChange = -delta.y * zoomSpeed;
            cameraObject.transform.Translate(0f, 0f, zoomChange, Space.Self);
        }

        // Middle Mouse Button: Pan
        if (mouseMiddle.IsPressed())
        {
            Vector3 right = cameraObject.transform.right;
            Vector3 up    = cameraObject.transform.up;
            float h = delta.x * panSpeed;
            float v = delta.y * panSpeed;

            cameraObject.transform.Translate(-right * h, Space.World);
            cameraObject.transform.Translate(-up * v,   Space.World);
        }

        // Left Mouse Button: Orbit around focalPoint
        if (mouseLeft.IsPressed() && focalPoint != null)
        {
            float h = delta.x * rotationSpeed;
            float v = delta.y * rotationSpeed;

            // Horizontal orbit around world up
            cameraObject.transform.RotateAround(focalPoint.transform.position, Vector3.up, h);
            // Vertical orbit around camera right (invert like original)
            cameraObject.transform.RotateAround(focalPoint.transform.position, cameraObject.transform.right, -v);
        }
    }

    void ResetCamera()
    {
        if (cameraObject != null)
        {
            cameraObject.transform.position = defaultPosition;
            cameraObject.transform.rotation = defaultRotation;
        }
        Debug.Log("Camera reset to default position and rotation.");
    }

    void SetDefaults()
    {
        if (cameraObject != null)
        {
            defaultPosition = cameraObject.transform.position;
            defaultRotation = cameraObject.transform.rotation;
        }
    }
}
