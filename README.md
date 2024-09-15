# Camera Controller

This script allows for basic camera manipulation including panning, zooming, and rotating around a specified target in a Unity scene.

## Setup Instructions

1. **Clone the Repository:**
   ```sh
   git clone https://github.com/hsuehyt/CameraController.git
   ```

2. **Create GameObjects in the Scene:**
   - Open your Unity project.
   - In the Hierarchy, create two empty GameObjects. These GameObjects can be named **anything** you like, but one will serve as the **Point of View (POV)** and the other as the **Focal Point**.

3. **Assign the Script:**
   - Attach the `CameraController.cs` script to any GameObject (e.g., your main camera or another object).
   - In the Inspector, assign the two newly created GameObjects to the `POV` and `Focal Point` fields.
     - The first GameObject serves as the **POV**, the point from which the camera operates.
     - The second GameObject serves as the **Focal Point**, the point around which the camera will rotate.

4. **Reposition GameObjects:**
   - You can freely reposition the **POV** and **Focal Point** GameObjects anywhere in the scene. Their initial position and rotation will serve as reference points for the camera’s movement and rotation.

5. **Ensure Correct Assignment:**
   - The names of these GameObjects do not matter, as long as they are properly assigned to the `POV` and `Focal Point` variables in the Unity Inspector.

## Usage

- **Pan:** Middle mouse button + mouse movement
- **Zoom:** Right mouse button + mouse movement (up/down)
- **Rotate:** Left mouse button + mouse movement (around the `Focal Point`)
- **Reset to Default Position:** Press `F`