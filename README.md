# Tower Defense

**CSCI 381 — Video Game Design and Development**  
**Fall 2026 — Assignment 2**

## Project Overview

Tower Defense is a 3D game developed using Unity 6. Players must strategically place defensive towers along a winding path to prevent enemies from reaching the end.

The game features multiple enemy types, two tower types, automatic shooting, predictive aiming, and three progressively challenging waves.

## How to Play

1. Select a tower using the **1** or **2** keys.
2. Left-click on the grass to place the selected tower.
3. Players can place a maximum of **5 towers**.
4. Towers automatically detect, aim at, and shoot nearby enemies.
5. Defend against three waves of enemies.
6. Destroy all enemies to win.
7. If even one enemy reaches the end of the path, the game ends.
8. Use the **Restart Game** button to play again.

## Controls

| Key / Action | Function |
|---|---|
| 1 | Select Basic Tower |
| 2 | Select Tall Tower |
| Left Mouse Click | Place selected tower on grass |
| Restart Game | Restart after winning or losing |

## Game Features

### 1. Tower Types

**Basic Tower**
- Blue tower with a shorter body.
- Faster firing rate.
- Slower projectile speed.
- Automatically targets nearby enemies.

**Tall Tower**
- Purple tower with a taller body.
- Slower firing rate.
- Faster projectile speed.
- Automatically targets nearby enemies.

Both towers use projectiles with Unity's 3D physics and collision detection.

### 2. Enemy Types

**Normal Enemy (Red)**
- Moves at a slower speed.
- Has higher health.
- Follows the predetermined path.

**Fast Enemy (Blue)**
- Moves faster than the normal enemy.
- Has lower health.
- Creates an additional challenge for tower targeting.

### 3. Enemy Wave System

The game includes three waves with increasing difficulty.

- **Wave 1:** 3 Normal Enemies.
- **Wave 2:** 3 Normal Enemies and 2 Fast Enemies.
- **Wave 3:** 3 Normal Enemies and 4 Fast Enemies.

Enemies spawn sequentially rather than appearing simultaneously.

Each wave begins after the previous wave is cleared and a short preparation period has passed.

The game ends in victory after all three waves are completed successfully.

### 4. Predictive Aiming

Towers use predictive aiming to calculate where moving enemies are expected to be when a projectile reaches them.

The prediction considers:
- The enemy's current position.
- The enemy's movement velocity.
- The projectile's travel speed.
- The tower's firing position.

This allows towers to aim ahead of moving enemies rather than simply shooting at their current locations.

### 5. Tower Placement System

- Players select between two tower types.
- Towers can only be placed on the grassy ground.
- Players are limited to five towers.
- The interface displays the selected tower and remaining tower count.

### 6. Game Over and Victory Conditions

**Victory:** All enemies across the three waves are destroyed.

**Game Over:** An enemy reaches the end of the path.

Both outcomes display a message and provide a Restart Game button.

### 7. Environment and Visual Design

The game features a 3D battlefield with:
- A winding enemy path.
- Green terrain.
- Trees and vegetation.
- Rocks, fences, and environmental decorations.
- Differently colored towers and enemies.
- Enlarged instruction, victory, and defeat panels.

## How to Run the Project

**Unity Version:** 6000.6.0f1

1. Clone or download this GitHub repository.
2. Open Unity Hub.
3. Select **Add project from disk**.
4. Select the `Game` folder inside the repository.
5. Open the project in Unity.
6. Open `Assets/MainScene.unity`.
7. Press **Play** to start the game.

## Project Structure

The Unity project is located inside the `Game` folder.

**Important folders and files:**

- `Game/Assets/MainScene.unity` — Main game scene.
- `Game/Assets/Scripts/` — Gameplay scripts.
- `Game/Assets/Prefabs/` — Tower, projectile, and enemy prefabs.
- `Game/Assets/Environment/` — Imported environment assets.
- `Game/Packages/` — Unity package dependencies.
- `Game/ProjectSettings/` — Unity project settings.

### Main Scripts

| Script | Purpose |
|---|---|
| GameManager.cs | Manages victory, defeat, and restarting |
| EnemyMovement.cs | Moves enemies along waypoints |
| EnemyHealth.cs | Manages enemy health and damage |
| EnemySpawner.cs | Controls enemy spawning and waves |
| TowerAim.cs | Calculates predictive aiming |
| TowerShoot.cs | Controls automatic projectile firing |
| TowerPlacement.cs | Allows players to place towers |
| Projectile.cs | Handles projectile movement and collisions |

## Assets and Credits

**Environment Assets:** [Kenney — Nature Kit](https://kenney.nl/assets/nature-kit)

The Nature Kit provides 3D environmental models and is available under the CC0 license.

**Development:** Created for CSCI 381 using Unity and AI-assisted programming.

## Assignment Requirements

The project implements the C, B, and A-level features described in Assignment 2:

- Player-controlled tower placement.
- Continuous automatic shooting.
- Tower targeting.
- Non-straight enemy paths.
- Game Over condition.
- Two tower types with different statistics.
- On-screen placement instructions.
- Limited tower placement.
- Multiple enemy types with different health and speeds.
- Non-basic 3D assets.
- Predictive aiming based on enemy position and velocity.

**Additional features:**
- Three progressively challenging enemy waves.
- Enemy spawning intervals.
- Victory condition.
- Restart functionality.
- Improved interface and environmental design.

---

**CSCI 381 — Video Game Design and Development | Fall 2026**
