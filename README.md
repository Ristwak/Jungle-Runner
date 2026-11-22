# Jungle Runner

A 2D mobile survival runner game developed using Unity and C#.

## Project Overview

Jungle Runner is a portrait-oriented 2D mobile game featuring continuous vertical environment scrolling. The player must navigate through incoming enemies and environmental hazards, using jumps to survive and achieve the highest possible score.

## Gameplay Features

- **Vertical Scrolling Environment:** The background continuously moves downward to create an endless survival-style gameplay experience.
- **Player Movement:** The character transitions between left and right movement animations through animation events.
- **Jump Mechanic:** Players can use the on-screen mobile button to jump and avoid enemies.
- **Enemy Spawning:** Enemies appear as the environment progresses.
- **Multiple Enemy Types:** Includes Bee and Ninja enemy behaviours.
- **Projectile Attacks:** Ninja enemies launch shurikens toward the player.
- **Environmental Hazards:** Tree obstacles can cause player death.
- **Height-Based Score:** The score increases during gameplay and represents the player's survival progress.
- **Game Over System:** Displays the final height score and provides options to restart or return to the main menu.

## Controls

**Mobile**
- Tap the on-screen Jump button to jump.

**Keyboard**
- Press `Space` to jump when using keyboard input.

## Technical Overview

| Property | Details |
|---|---|
| Game Engine | Unity 2022.3.22f1 |
| Programming Language | C# |
| Game Type | 2D Survival Runner |
| Target Platform | Mobile |
| Orientation | Portrait |
| UI System | Unity UI |
| Physics | Unity 2D Physics and Trigger Collisions |

## Core Scripts

| Script | Responsibility |
|---|---|
| `BGMover.cs` | Background scrolling, repositioning and enemy spawning |
| `Player.cs` | Jump input, player animations, collision handling and death |
| `GameplayController.cs` | Score tracking, game-over screen and scene navigation |
| `BeeScript.cs` | Bee enemy movement and attack behaviour |
| `NinjaScript.cs` | Ninja enemy movement and shuriken spawning |
| `ShurikenScript.cs` | Shuriken movement and deactivation |
| `EnemyMove.cs` | Basic enemy movement and deactivation |
| `MainMenuScript.cs` | Main menu gameplay-scene navigation |

## Project Setup

1. Clone or download the repository.
2. Open the project in Unity 2022.3.22f1.
3. Allow Unity to import the project assets.
4. Ensure the required scenes are included in Build Settings.
5. Open the main menu scene to access the game.

## Development Notes

The project uses Unity animation components, UI elements, audio sources, and 2D trigger-based collision detection to implement its gameplay systems.

The gameplay scripts have been updated to improve code reliability, enemy behaviour, player input handling, and score management while preserving the existing gameplay structure.

---

**Project:** Jungle Runner  
**Engine:** Unity  
**Language:** C#  
**Target:** Mobile
