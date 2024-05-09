# CameraController

---

#### Overview
`CameraController` is a versatile Unity3D script designed to provide intuitive and customizable camera controls similar to those found in Unity's Editor. It allows users to pan, zoom, and rotate the camera during runtime, enhancing the usability of any scene. Additionally, the script includes a feature to reset the camera to its original position and orientation.

#### Features
- **Zoom:** Alt + Right Mouse Button + Move Mouse Vertically
- **Pan:** Alt + Middle Mouse Button + Move Mouse
- **Orbit/Tumble:** Alt + Left Mouse Button + Move Mouse
- **Reset Camera:** Press 'F' to reset to the default camera position and orientation

#### Requirements
- Unity 2019.4 LTS or later is recommended to ensure full compatibility.

#### Installation
1. **Create the Script:**
   - Navigate to the Assets folder in Unity's Project pane.
   - Right-click and select Create > C# Script.
   - Name the script `CameraController`.
   - Open the script in your preferred code editor.

2. **Script Setup:**
   - Copy and paste the provided script code into the `CameraController` script file.

3. **Attach to Camera:**
   - Drag the script onto the camera object in your scene that you wish to control.

4. **Configure Script Parameters:**
   - With the camera selected, adjust the script parameters in the Inspector to suit your needs. Parameters include `panSpeed`, `zoomSpeed`, `rotationSpeed`, as well as initial `defaultPosition` and `defaultRotation`.

#### Usage
After setup, enter Play mode in Unity to interact with the camera:
- **Zoom:** Hold Alt and the right mouse button, then move the mouse vertically.
- **Pan:** Hold Alt and the middle mouse button, then move the mouse.
- **Orbit/Tumble:** Hold Alt and the left mouse button, then move the mouse.
- **Reset:** Simply press the 'F' key to reset the camera to its default settings.

#### Contributing
Contributions to enhance `CameraController`, fix issues, or improve documentation are warmly welcomed. Please feel free to fork the repository, make your changes, and submit a pull request.

#### License
This project is licensed under the MIT License - see the LICENSE file in the source repository for more details.
