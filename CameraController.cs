using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 0.5f;
    public float zoomSpeed = 0.2f; // Adjusted for smoother zoom control
    public float rotationSpeed = 5f;
    public Vector3 defaultPosition;
    public Quaternion defaultRotation;

    // Updated variable names
    [SerializeField] private GameObject POV; // Point of View
    [SerializeField] private GameObject focalPoint; // Focal Point
    [SerializeField] private Camera cameraObject; // Reference to the actual camera object

    void Start()
    {
        // Only assign if not already set in the editor
        if (POV == null)
        {
            POV = GameObject.Find("POV");
        }

        if (focalPoint == null)
        {
            focalPoint = GameObject.Find("Focal Point");
        }

        if (cameraObject == null)
        {
            cameraObject = Camera.main; // Assign the main camera if not assigned
        }

        SetDefaults();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            HandleMouseInput();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ResetCamera();
        }
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButton(1)) // Right Mouse Button
        {
            // Zooming - invert the Y-axis for zoom
            float zoomChange = -Input.GetAxis("Mouse Y") * zoomSpeed;
            cameraObject.transform.Translate(0, 0, zoomChange, Space.Self);
        }
        if (Input.GetMouseButton(2)) // Middle Mouse Button
        {
            // Panning
            Vector3 right = cameraObject.transform.right;
            Vector3 up = cameraObject.transform.up;
            float h = Input.GetAxis("Mouse X") * panSpeed;
            float v = Input.GetAxis("Mouse Y") * panSpeed;
            cameraObject.transform.Translate(-right * h, Space.World);
            cameraObject.transform.Translate(-up * v, Space.World);
        }
        if (Input.GetMouseButton(0)) // Left Mouse Button
        {
            // Tumbling/Orbiting around "focalPoint"
            float h = Input.GetAxis("Mouse X") * rotationSpeed;
            float v = Input.GetAxis("Mouse Y") * rotationSpeed;

            if (focalPoint != null)
            {
                // Rotate around the focalPoint's position horizontally and vertically
                cameraObject.transform.RotateAround(focalPoint.transform.position, Vector3.up, h);
                cameraObject.transform.RotateAround(focalPoint.transform.position, cameraObject.transform.right, -v);
            }
        }
    }

    void ResetCamera()
    {
        if (cameraObject != null)
        {
            cameraObject.transform.position = defaultPosition; // Reset to default position
            cameraObject.transform.rotation = defaultRotation; // Reset to default rotation
        }
        Debug.Log("Camera reset to default position and rotation.");
    }

    void SetDefaults()
    {
        if (cameraObject != null)
        {
            defaultPosition = cameraObject.transform.position; // Save the initial position as default
            defaultRotation = cameraObject.transform.rotation; // Save the initial rotation as default
        }
    }
}
