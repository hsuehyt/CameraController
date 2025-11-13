# Camera Controller

This script provides Scene-View-style camera navigation inside Unity — including **orbit**, **pan**, **zoom**, and **reset** — using the **Unity Input System**.

---

## ⚠️ Fix for `CS0246: InputAction not found`

If you encounter this error:

```
error CS0246: The type or namespace name 'InputAction' could not be found
```

Follow these steps:

### **1. Install Input System**

Go to:

**Window → Package Manager → (Unity Registry) → Input System → Install**

### **2. Enable Input System in Player Settings**

Go to:

**Edit → Project Settings → Player → Other Settings → Active Input Handling**

Set:

✔ **Both**
(or **Input System Package (New)**)

Unity will ask you to restart the editor — click Restart.

---

## 🎮 Setup Instructions

### **1. Clone the Repository**

```sh
git clone https://github.com/hsuehyt/CameraController.git
```

### **2. Create Required GameObjects**

In your Unity scene:

* Create an empty GameObject to act as the **POV** (camera pivot).
* Create another empty GameObject as the **Focal Point** (orbit center).
* Name them however you like.

### **3. Assign Script References**

Attach `CameraController.cs` to the camera (or any object controlling the camera).
In the Inspector:

* Assign **POV** → the pivot point the camera moves from.
* Assign **Focal Point** → the point the camera orbits around.

### **4. Adjust Transform Positions Freely**

The initial positions of POV and Focal Point determine the center and feel of the navigation system.
You may reposition them anytime.

---

## 🕹 Usage Controls

| Action           | Input                                                   |
| ---------------- | ------------------------------------------------------- |
| **Orbit**        | **Left Mouse Button** + Move (with **Alt** key pressed) |
| **Pan**          | **Middle Mouse Button** + Move                          |
| **Zoom (Drag)**  | **Right Mouse Button** + Move                           |
| **Scroll Zoom**  | Mouse Scroll Wheel                                      |
| **Reset Camera** | Press **F**                                             |

---

## ✔ Notes

* Script uses **UnityEngine.InputSystem** (new Input System).
* Requires **Active Input Handling = Both** or **Input System Package (New)**.
* Focal Point can be swapped dynamically if needed.
