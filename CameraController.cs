using UnityEngine;
using UnityEngine.InputSystem; // New Input System

public class CameraController : MonoBehaviour
{
    [Header("Speeds (tuned to feel like Scene View)")]
    public float panSpeed = 0.0001f;      // Adjusted for pixel delta sensitivity
    public float zoomSpeed = 0.05f;      // Scroll/drag zoom sensitivity
    public float rotationSpeed = 0.2f;   // Orbit sensitivity (degrees per pixel)

    [Header("Defaults (auto-filled on Start)")]
    public Vector3 defaultPosition;
    public Quaternion defaultRotation;

    [Header("Scene References")]
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private Camera cameraObject;

    // Input Actions
    private InputAction altKey;
    private InputAction resetKey;
    private InputAction mouseDelta;
    private InputAction mouseLeft;
    private InputAction mouseMiddle;
    private InputAction mouseRight;
    private InputAction scroll;

    // ---------- NEW: public accessors ----------
    public GameObject GetFocalPoint() => focalPoint;
    public void SetFocalPoint(GameObject go) => focalPoint = go;

    void Awake()
    {
        altKey = new InputAction("Alt", binding: "<Keyboard>/leftAlt");
        resetKey = new InputAction("Reset", binding: "<Keyboard>/f");
        mouseDelta = new InputAction("MouseDrag", binding: "<Mouse>/delta");
        mouseLeft = new InputAction("LMB", binding: "<Mouse>/leftButton");
        mouseMiddle = new InputAction("MMB", binding: "<Mouse>/middleButton");
        mouseRight = new InputAction("RMB", binding: "<Mouse>/rightButton");
        scroll = new InputAction("Scroll", binding: "<Mouse>/scroll");
    }

    void OnEnable()
    {
        altKey.Enable();
        resetKey.Enable();
        mouseDelta.Enable();
        mouseLeft.Enable();
        mouseMiddle.Enable();
        mouseRight.Enable();
        scroll.Enable();
    }

    void OnDisable()
    {
        altKey.Disable();
        resetKey.Disable();
        mouseDelta.Disable();
        mouseLeft.Disable();
        mouseMiddle.Disable();
        mouseRight.Disable();
        scroll.Disable();
    }

    void Start()
    {
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

        HandleScrollZoom();
    }

    void HandleMouseInput()
    {
        if (cameraObject == null) return;

        Vector2 delta = mouseDelta.ReadValue<Vector2>();

        // RMB: smooth zoom drag
        if (mouseRight.IsPressed())
        {
            float zoomChange = -delta.y * zoomSpeed;
            cameraObject.transform.Translate(0f, 0f, zoomChange, Space.Self);
        }

        // MMB: pan
        if (mouseMiddle.IsPressed())
        {
            Vector3 right = cameraObject.transform.right;
            Vector3 up = cameraObject.transform.up;
            float h = delta.x * panSpeed * cameraObject.transform.position.magnitude * 10f;
            float v = delta.y * panSpeed * cameraObject.transform.position.magnitude * 10f;
            cameraObject.transform.Translate(-right * h, Space.World);
            cameraObject.transform.Translate(-up * v, Space.World);
        }

        // LMB: orbit
        if (mouseLeft.IsPressed() && focalPoint != null)
        {
            float h = delta.x * rotationSpeed;
            float v = delta.y * rotationSpeed;

            cameraObject.transform.RotateAround(focalPoint.transform.position, Vector3.up, h);
            cameraObject.transform.RotateAround(focalPoint.transform.position, cameraObject.transform.right, -v);
        }
    }

    void HandleScrollZoom()
    {
        if (cameraObject == null) return;

        Vector2 scrollValue = scroll.ReadValue<Vector2>();
        if (Mathf.Abs(scrollValue.y) > 0.01f)
        {
            float scrollZoom = scrollValue.y * zoomSpeed * 10f;
            cameraObject.transform.Translate(0f, 0f, scrollZoom, Space.Self);
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
