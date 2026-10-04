# 🟡 Connect Four — Unity 2D

![Unity Version](https://img.shields.io/badge/Unity-6000.0.0f1%206-blue?logo=unity)
![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20PC-lightgrey)
![Language](https://img.shields.io/badge/Language-C%23-green?logo=c-sharp)
![License](https://img.shields.io/badge/License-MIT-orange)

A modern, polished 2D Connect Four implementation built in **Unity 6**. Features custom-styled UI elements, translucent matte cell cutouts, dynamic turn indicators, and efficient grid evaluation logic.

---

## 🎮 Game Overview

Connect Four is a classic two-player strategy game where players take turns dropping colored discs into a 7-column, 6-row vertically suspended grid. The objective is to be the first to form a horizontal, vertical, or diagonal line of four matching discs.

---

## ✨ Features

- **Custom UI Visuals:** Translucent matte cell cutouts designed for an embedded board aesthetic over custom backdrop imagery.
- **Responsive Controls:** Smooth column selection with visual indicators for piece drops.
- **Dynamic Turn System:** Real-time UI updates highlighting current player turn and game state transitions.
- **Win Detection Engine:** Lightweight directional evaluation system that instantly checks horizontal, vertical, and diagonal win vectors upon every drop.
- **Cross-Resolution Scaling:** Fully scalable Canvas setup designed to support 16:9 and 16:10 displays seamlessly.

---

## 🛠️ Tech Stack & Requirements

| Specification | Requirement / Details |
| :--- | :--- |
| **Engine** | Unity 6 (`6000.0.0f1`) |
| **Render Pipeline** | Universal Render Pipeline (URP) |
| **Language** | C# (.NET Standard) |
| **Input System** | Unity Input System / Legacy UI Events |
| **Target Platform** | Standalone PC (Windows 64-bit) |

---

## 📁 Project Structure

```text
Connect Four/
├── Assets/
├── Packages/
├── ProjectSettings/
├── .gitignore
├── README.md
└── Connect Four.slnx
🚀 Getting StartedPrerequisitesMake sure you have Unity Hub installed along with Unity Editor version 6000.0.0f1.Installation StepsClone the repository:Bashgit clone [https://github.com/yashintocodes/ConnectFour.git](https://github.com/yashintocodes/ConnectFour.git)
Open Unity Hub.Click Add $\rightarrow$ Add project from disk.Select the cloned Connect Four root folder.Launch the project with Unity 6000.0.0f1.🖥️ How to PlayLaunch the game and select your starting turn.Click on any of the 7 board columns to drop a disc into the lowest available slot.Alternate turns between Player 1 (Red) and Player 2 (Yellow).Connect 4 matching discs in a line to trigger the victory screen!📜 LicenseDistributed under the MIT License. See LICENSE for more information.
---

### Step-by-Step GitHub Upload Instructions:

1. In your browser page, replace all existing text in the editor with the markdown above.
2. Scroll to the top right corner and click the green **`Commit changes...`** button.
3. Click **`Commit changes`** in the pop-up modal.

4. Open your local **Git Bash** terminal and sync your local folder by typing:
   ```bash
   git pull
