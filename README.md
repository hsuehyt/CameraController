# Camera Controller

This script allows for basic camera manipulation including panning, zooming, and rotating around a specified target in a Unity scene.

## Setup Instructions

1. **Clone the Repository:**
   ```sh
   git clone https://github.com/hsuehyt/CameraController.git
   ```

2. **Create GameObjects in the Scene:**
   - Open your Unity project.
   - In the Hierarchy, right-click and create two empty GameObjects.
   - Name them exactly as follows:
     - `userPoint`
     - `cameraAim`

3. **Organize Hierarchy:**
   - Drag the `Main Camera` under `userPoint`.

4. **Assign the Script:**
   - Attach the `CameraController.cs` script to any GameObject (e.g., `userPoint`).
   - In the Inspector, assign the `userPoint` and `cameraAim` GameObjects to their respective fields in the script.

5. **Ensure Correct Naming:**
   - Make sure the names are case-sensitive and exactly match `userPoint` and `cameraAim`.

## Usage

- **Pan:** Middle mouse button + mouse movement
- **Zoom:** Right mouse button + mouse movement (up/down)
- **Rotate:** Left mouse button + mouse movement (around `cameraAim`)
- **Reset to Default Position:** Press `F`
