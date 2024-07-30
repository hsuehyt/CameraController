using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 0.5f;
    public float zoomSpeed = 0.2f; // Adjusted for smoother zoom control
    public float rotationSpeed = 5f;
    public Vector3 defaultPosition;
    public Quaternion defaultRotation;

    private GameObject userPoint; // Reference to the UserPoint GameObject
    private GameObject cameraAim; // Reference to the cameraAim GameObject

    void Start()
    {
        userPoint = GameObject.Find("userPoint"); // Find the UserPoint GameObject in the scene
        cameraAim = GameObject.Find("cameraAim"); // Find the cameraAim GameObject in the scene
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
            // Zooming
            float zoomChange = Input.GetAxis("Mouse Y") * zoomSpeed;
            userPoint.transform.Translate(0, 0, zoomChange, Space.Self);
        }
        if (Input.GetMouseButton(2)) // Middle Mouse Button
        {
            // Panning
            Vector3 right = userPoint.transform.right;
            Vector3 up = userPoint.transform.up;
            float h = Input.GetAxis("Mouse X") * panSpeed;
            float v = Input.GetAxis("Mouse Y") * panSpeed;
            userPoint.transform.Translate(-right * h, Space.World);
            userPoint.transform.Translate(-up * v, Space.World);
        }
        if (Input.GetMouseButton(0)) // Left Mouse Button
        {
            // Tumbling/Orbiting around "cameraAim"
            float h = Input.GetAxis("Mouse X") * rotationSpeed;
            float v = Input.GetAxis("Mouse Y") * rotationSpeed;

            if (cameraAim != null)
            {
                // Rotate around the cameraAim's position horizontally and vertically
                userPoint.transform.RotateAround(cameraAim.transform.position, Vector3.up, h);
                userPoint.transform.RotateAround(cameraAim.transform.position, userPoint.transform.right, -v);
            }
        }
    }

    void ResetCamera()
    {
        if (cameraAim != null)
        {
            userPoint.transform.position = defaultPosition; // Reset to default position
            userPoint.transform.rotation = defaultRotation; // Reset to default rotation
        }
        Debug.Log("Camera reset to default position and rotation.");
    }

    void SetDefaults()
    {
        if (cameraAim != null)
        {
            defaultPosition = userPoint.transform.position; // Save the initial position as default
            defaultRotation = userPoint.transform.rotation; // Save the initial rotation as default
        }
    }
}
