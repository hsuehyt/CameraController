using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 0.5f;
    public float zoomSpeed = 0.2f; // Adjusted for smoother zoom control
    public float rotationSpeed = 5f;
    public Vector3 defaultPosition;
    public Quaternion defaultRotation;

    private Camera cam;
    private GameObject sphere; // Reference to the Sphere GameObject

    void Start()
    {
        cam = Camera.main; // Get the main camera
        sphere = GameObject.Find("Sphere"); // Find the Sphere GameObject in the scene
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
            cam.transform.Translate(0, 0, zoomChange, Space.Self);
        }
        if (Input.GetMouseButton(2)) // Middle Mouse Button
        {
            // Panning
            Vector3 right = cam.transform.right;
            Vector3 up = cam.transform.up;
            float h = Input.GetAxis("Mouse X") * panSpeed;
            float v = Input.GetAxis("Mouse Y") * panSpeed;
            cam.transform.Translate(-right * h, Space.World);
            cam.transform.Translate(-up * v, Space.World);
        }
        if (Input.GetMouseButton(0)) // Left Mouse Button
        {
            // Tumbling/Orbiting around "Sphere"
            float h = Input.GetAxis("Mouse X") * rotationSpeed;
            float v = Input.GetAxis("Mouse Y") * rotationSpeed;

            if (sphere != null)
            {
                // Rotate around the Sphere's position horizontally and vertically
                cam.transform.RotateAround(sphere.transform.position, Vector3.up, h);
                cam.transform.RotateAround(sphere.transform.position, cam.transform.right, -v);
            }
        }
    }

    void ResetCamera()
    {
        if (sphere != null)
        {
            cam.transform.position = defaultPosition; // Reset to default position
            cam.transform.rotation = defaultRotation; // Reset to default rotation
        }
        Debug.Log("Camera reset to default position and rotation.");
    }

    void SetDefaults()
    {
        if (sphere != null)
        {
            defaultPosition = cam.transform.position; // Save the initial position as default
            defaultRotation = cam.transform.rotation; // Save the initial rotation as default
        }
    }
}
