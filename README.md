# CameraController

The CameraController is a Unity script designed to enhance 3D camera manipulation, allowing users to emulate camera control similar to what is experienced in professional 3D applications like Maya. This script supports panning, zooming, and orbiting around a designated focus point.

## Features

- **Panning:** Move the camera parallel to the viewing plane.
- **Zooming:** Move the camera closer or further away from the focus point.
- **Orbiting:** Rotate the camera around the focus point in both horizontal and vertical axes.

## Installation

To use the CameraController in your Unity project, follow these steps:

1. Clone or download this repository.
2. Import the `CameraController.cs` script into your Unity project.
3. Attach the `CameraController` script to the camera GameObject you wish to control.
4. Set the `UserPoint` GameObject in the Unity editor to designate the focus point for camera movements.

## Usage

### Key Controls
- **Alt + Right Mouse Button:** Zoom in and out.
- **Alt + Middle Mouse Button:** Pan the camera.
- **Alt + Left Mouse Button:** Orbit around the `cameraAim`.

### Resetting the Camera
- **Press 'F':** Reset the camera to its default position and orientation.
