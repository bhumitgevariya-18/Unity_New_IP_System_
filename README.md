![Image](https://github.com/user-attachments/assets/6e56bd1e-7d6e-4221-8f26-2fa56b63c3e5)

# Unity Camera Controller

A flexible Unity project focused on advanced camera movement and input customization. This project demonstrates a modular camera system with runtime key rebinding, smooth movement, zoom, and rotation controls, suitable for strategy, simulation, or sandbox games.

---

## Project Description

This project provides a robust camera controller for Unity, allowing users to navigate, zoom, and rotate the camera using keyboard, mouse, or gamepad. It leverages Unity's Input System for modern input handling and supports runtime key rebinding via a simple UI. The system is designed for extensibility and can be integrated into various game genres requiring freeform camera movement.

---

## Features

- **Camera Movement**: Move the camera horizontally and vertically within defined bounds.
- **Height Adjustment**: Raise or lower the camera smoothly.
- **Zoom**: Dynamic field-of-view zooming with clamped limits.
- **Rotation**: Rotate the camera using input axes and a UI slider for sensitivity.
- **Speed Modes**: Toggle between walking and running speeds.
- **Custom Key Bindings**: Change movement keys at runtime using a UI (requires TextMeshPro).
- **Input System Integration**: Uses Unity's Input System for flexible input mapping.
- **UI Integration**: Includes a slider for rotation sensitivity and input fields for key rebinding.

---

## How to Play / Controls

Default controls (customizable in-game):

| Action         | Default Key / Input      |
|----------------|-------------------------|
| Move           | WASD / Arrow Keys / Gamepad Left Stick |
| Raise Camera   | E / Gamepad Button      |
| Lower Camera   | Q / Gamepad Button      |
| Zoom           | Mouse Scroll / Gamepad Trigger |
| Rotate         | Mouse Drag / Gamepad Right Stick |
| Run            | Left Shift              |
| Walk           | Left Ctrl               |

- **Rotation Sensitivity**: Adjust using the on-screen slider.

---

## Dependencies

- **Unity Version**: (Check `ProjectSettings/ProjectVersion.txt` for exact version; recommended Unity 2021.3+)
- **Packages**:
  - Input System (`com.unity.inputsystem`)
  - TextMeshPro (`com.unity.textmeshpro`)
- **Other**: No third-party assets required.

---

## Installation & Setup

1. **Clone or Download** this repository.
2. **Open in Unity Hub**: Select the project folder.
3. **Install Dependencies**: Unity will prompt to install missing packages.
4. **Open Scene**: Load `Assets/Scenes/Main.unity` (or your main scene).
5. **Play**: Press Play in the Unity Editor to test camera controls and UI.

**Build Instructions**:
- Use Unity's Build Settings to export for your target platform (PC, Mac, etc.).

---

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature/YourFeature`).
3. Commit your changes.
4. Submit a pull request with a clear description.

---

## Known Issues & Future Improvements

- No multiplayer or AI features included.
- UI for key rebinding is basic; could be improved for better UX.
- Camera collision and smoothing can be enhanced.
- Add support for touch/mobile controls.
- More camera modes (e.g., follow, orbit) can be added.
- Key Rebinding**: In-game UI to assign new keys for movement directions.

---
