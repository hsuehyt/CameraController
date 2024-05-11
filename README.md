# Camera Controller for Unity

## Overview

The `CameraController` script provides versatile camera control functionalities for Unity applications, allowing the camera to pan, zoom, and orbit around a designated GameObject named "Sphere". This script is designed to be attached to a camera object in a Unity scene to enable dynamic and intuitive camera movements through mouse inputs.

## Features

- **Zoom**: Adjust the camera's distance relative to the "Sphere" using the right mouse button.
- **Pan**: Move the camera parallel to its current viewing plane using the middle mouse button.
- **Orbit/Tilt**: Rotate the camera around the "Sphere", allowing both horizontal orbiting and vertical tilting using the left mouse button.

## Setup

### Requirements

- Unity 2019.4 LTS or later
- A scene with at least one camera and a GameObject named "Sphere"

### Installation

1. **Create or Open Your Unity Project**:
   - Launch Unity and either create a new project or open an existing one where you intend to use this camera control.

2. **Add the Script**:
   - Create a new script in Unity named `CameraController`.
   - Copy the provided `CameraController` code into this script using Unity's script editor or your preferred text editor.

3. **Prepare the Scene**:
   - Ensure your scene has a camera object. This will typically be the Main Camera.
   - Add a GameObject to your scene and name it "Sphere". This object will serve as the pivot point around which the camera moves.

4. **Attach the Script**:
   - Drag the `CameraController` script onto your Main Camera in the scene to attach it as a component.

5. **Configure the Script** (Optional):
   - Select the camera in your scene hierarchy.
   - In the Inspector panel, you will see the `CameraController` component with several adjustable parameters such as `panSpeed`, `zoomSpeed`, and `rotationSpeed`. Adjust these parameters as needed to fine-tune the camera's responsiveness.

## Usage

- **Activate Camera Controls**:
  - Hold the **Left Alt** key to activate the camera controls.
- **Camera Movements**:
  - **Zoom**: Click and hold the right mouse button, then move the mouse forward or backward.
  - **Pan**: Click and hold the middle mouse button, then move the mouse in any direction.
  - **Orbit/Tilt**: Click and hold the left mouse button, then move the mouse to orbit horizontally or tilt vertically.

- **Reset Camera**:
  - Press the **F** key to reset the camera to its default position and orientation.

## Support

For support, feature requests, or bug reports, please open an issue in the GitHub repository linked to this project or contact the developer directly through [Developer Contact Information].