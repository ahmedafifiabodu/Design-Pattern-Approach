# Unity Design Pattern Project

## Overview

The Unity Design Pattern project is a comprehensive showcase of various design patterns implemented within a Unity game development context. It aims to demonstrate best practices in structuring game code, managing dependencies, and optimizing performance, making it an invaluable resource for both novice and experienced Unity developers.

<div align="center">
  <video src="https://github.com/ahmedafifiabodu/Unity-Design-Pattern-Project/assets/74466733/3b8470e9-657f-4980-a016-18e468993574" width="400" />
</div>

## Features

- **Service Locator Pattern**: Centralized management of services to reduce dependencies and facilitate easy access across the project.
- **State Pattern**: Implementation of enemy behaviours, allowing for dynamic and complex AI systems.
- **Object Pooling**: Efficient management of game objects, such as enemies and projectiles, to improve performance.
- **Observer Pattern**: Utilization of events to communicate changes in game state, such as player health updates.
- **Singleton Pattern**: Ensuring classes like `ServiceLocator` and `GameConstant` have a single, global point of access.

## Getting Started

To get started with the Unity Design Pattern project, follow these steps:

### Prerequisites

- Unity Editor (Version 2022.1 or later recommended)
- Basic understanding of Unity and C#

### Installation

1. Clone the repository to your local machine.
2. Open the project in Unity Editor.
3. Navigate to the `Scenes` folder and open the main scene to start exploring the project.

## Core Systems

### [Game Constant.cs](#game-constant.cs-context)
Defines constants used across the game, including tags and animation hashes, ensuring consistency and reducing the likelihood of errors due to typos.

### [Service Locator.cs](#service-locator.cs-context)
Implements the Service Locator pattern to manage dependencies, allowing for easy access to shared services throughout the game.

## Player Systems

### [Input Manager.cs](#input-manager.cs-context)
Handles player input, mapping actions to in-game behaviours, ensuring a responsive and intuitive control scheme.

### [Player Movement.cs](#player-movement.cs-context)
Controls the player's movement, including walking and jumping, providing a smooth and natural player experience.

### [Player Look.cs](#player-look.cs-context)
Manages the player's camera movement and orientation, enabling a fluid and immersive first-person view.

### [Player Health.cs](#player-health.cs-context)
Tracks and manages the player's health, handling damage and healing, central to the game's survival mechanics.

### [Player Event.cs](#player-event.cs-context)
Facilitates communication between player-related systems, using events to notify changes in player state, such as health updates.

## UI Systems

### [Health UI.cs](#health-ui.cs-context)
Updates the UI in response to changes in the player's health, providing visual feedback on the player's condition.

### [Colorful Text.cs](#colorful-text.cs-context)
Enhances UI text elements with dynamic colour changes, adding visual interest and improving user engagement.

## Enemy Systems

### [Enemy.cs](#enemy.cs-context)
Defines basic enemy behaviour, including interactions with the player and environment.

### [Enemy Manager.cs](#enemy-manager.cs-context) and [Enemy Manager (OLD).cs](#enemy-manager-(old).cs-context)
Manages enemy instances, handling spawning, tracking, and state management, central to the game's challenge and dynamics.

### [Enemy State Manager.cs](#enemy-state-manager.cs-context)
Controls the state machine for enemy behaviours, allowing for complex and varied AI patterns.

### [IEnemyState.cs](#ienemystate.cs-context)
Defines the interface for enemy states, ensuring consistency and facilitating state management.

### [Enemy Idle State.cs](#enemy-idle-state.cs-context), [Enemy Follow State.cs](#enemy-follow-state.cs-context), [Enemy Attacking State.cs](#enemy-attacking-state.cs-context), [Enemy Patrolling State.cs](#enemy-patrolling-state.cs-context), [Enemy Shooting State.cs](#enemy-shooting-state.cs-context)
Implement specific enemy behaviours, such as patrolling, following the player, and attacking, contributing to a dynamic and engaging enemy AI.

### [Enemy Pooling.cs](#enemy-pooling.cs-context)
Implements object pooling for efficient enemy instantiation and management, optimizing performance.

### [Enemies.cs](#enemies.cs-context) and [Enemies Editor.cs](#enemies-editor.cs-context)
Define enemy configurations and provide custom editor support for easy setup and management of enemy types.

## Attack and Damage Systems

### [Enemy Attack.cs](#enemy-attack.cs-context)
Handles enemy attacks, including collision detection and damage calculation, integral to the game's combat system.

### [Fireball.cs](#fireball.cs-context) and [Fire Pooling.cs](#fire-pooling.cs-context)
Implement projectile-based attacks, using object pooling for efficient management of fireball instances.

## Conclusion

This overview covers the core scripts and systems that form the foundation of the game. Each script plays a specific role in creating a cohesive and engaging game experience, from managing player and enemy behaviors to updating the UI and handling game events.

## Contributing

Contributions to the Unity Design Pattern project are welcome! To contribute:

1. Fork the repository.
2. Create a new branch for your feature (`git checkout -b feature/AmazingFeature`).
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`).
4. Push to the branch (`git push origin feature/AmazingFeature`).
5. Open a pull request.

## License

This project is licensed under the MIT License - see the LICENSE.md file for details.
