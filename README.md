# 🤖 Robot Dodge  
A SplashKit C# Arcade Game

Robot Dodge is a fast-paced 2D arcade-style game built using **C#** and **SplashKitSDK**.  
The player must move around the screen, avoid incoming robots, shoot bullets, and survive as long as possible while increasing their score.

---

## 🎮 Game Overview

You control a player character that can:

- Move using **arrow keys**
- Shoot bullets using the **mouse**
- Stay within window boundaries
- Avoid or collide with robots (collision replaces the robot with a new one)
- Track **lives** and **score**

Enemies (robots) spawn at random edges of the screen and move toward the player using vector math.

There are two robot types:

- **Boxy** — A square robot  
- **Roundy** — A circular robot  

As the player interacts with robots—either through shooting or collision—new robots are dynamically added.

## 🧱 Project Structure
---
/Robot_Dodge
│
├── Program.cs
├── Robot.cs
├──── Boxy.cs
├──── Roundy.cs
├── RobotDodge.cs
├── Player.cs
├── Bullet.cs
└── README.md


---

## 🕹 Controls

### Movement  
| Key | Action |
|-----|--------|
| ↑ | Move Up |
| ↓ | Move Down |
| → | Move Right |
| ← | Move Left |

### Other Actions  
| Input | Action |
|--------|--------|
| Left Mouse Click | Shoot bullet toward mouse position |
| ESC | Quit game |

---

## 👾 Gameplay Mechanics

### **Player**
- Starts in the center of the window.
- Has **5 lives**.
- Can move freely but stays inside the window.
- Can shoot bullets in any direction.
- Gains score when hitting enemies (you can expand scoring as needed).

### **Robots**
Robots spawn at random edges of the screen.  
Each robot:

- Moves toward the player (vector-based movement)
- Has a collision circle for accuracy
- Is removed when:
  - Colliding with the player  
  - Moving off-screen  
  - (Optional) Getting hit by a bullet

### **Bullets**
- Travel in the direction of the mouse click
- Disappear when off-screen
- Can collide with robots (collision logic available to extend)

---

## 🔧 Key Classes Explained

### **Program.cs**
- Creates the game window
- Runs the main game loop
- Handles events, updates, and drawing

### **Robot (abstract)**
- Base class for all robots
- Handles movement, collision circle, and spawning logic

### **Boxy & Roundy**
- Two visual robot variants
- Override the `Draw()` method to display their shapes

### **Player**
- Handles movement, lives, score, drawing hearts, drawing score
- Shoots bullets toward the mouse
- Detects collision with robots

### **Bullet**
- Moves forward each frame
- Draws a small circle
- Handles robot collision via circles intersecting

### **RobotDodge (Game Manager)**
- Stores player and robot list
- Handles:
  - Input
  - Updating robots
  - Spawning new robots
  - Removing off-screen or collided robots
  - Drawing all game objects

---

## 🛠 Requirements

- .NET 6.0+ recommended  
- SplashKit SDK installed  
- Image file:  
  - `images/Player.png` (used by the Player class)

---

## ▶ How to Run

1. Install SplashKit SDK  
2. Open the project folder  
3. Build & run:

```sh
dotnet run

## 🧱 Project Structure

