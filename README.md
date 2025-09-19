# 🐟 Flying Fish

## 🏷️ Team Information
### Group Name and Number
Group Name: CISC 486 Section 001 - 4
Group Number: 4

### Team Members' Names and Numbers
Name: Grace Codrington
Student Number: 20293222

Name: Liam Beenken
Student Number: 20364179

Name: Decheng Zhu
Student Number: 20124443

## 📌 Overview
Flying Fish is a 3D casual simulation game where an aquarium worker is trying to catch and throw back fish that are escaping from a leaking aquarium tank. The worker must catch as many escaping fish as possible, and look for ways to stop the leak. The longer the aquarium worker takes to stop the leak, the more obstacles appear. For example, more leaks form over time, puddles start forming on the ground that the worker can slip on, and different types of escaping fish wreak havoc.

## 🕹️ Core Gameplay
Players control the aquarium worker.\
Catch fish in your net, as they try to escape the leaky tank.\
Throw as many fish as possible back into the tank.\
Win by successfully stopping the leak.\
Lose if all water drains from the tank.\
Score higher on a level by catching and throwing back fish (2 points for every fish remaining in the tank, 1 for every fish caught in the net, but not thrown back).

## 🎯 Game Type
Casual Simulation/ Puzzle Adventure Game

## 👥 Player Setup
Single player as the aquarium worker.\
Optional Multiplayer version, with one player responsible for catching and throwing back fish, and one player responsible for finding and fixing the leak.\
Dual player interface design: Adopting a split screen layout(similar to It takes two), the left fisherman view displays the dynamic fish tank, and the right repairman view displays the leakage point status.


## 🤖 AI Design
### Basic Fish FSM
- Idle
- Random pathfinding around fish tank
- Pathfind towards leak if appears
- Jump out of leak (Physics Enabled)
- If caught in flight, parented to player net, physics disabled
- If not caught, idle flop around
- If thrown, in flight, animated, physics enabled

### Attacking Fish FSM
- Idle
- Aggressive pathfinding around fish tank
- Pathfind towards leak if appears
- Jump out of leak (Physics enabled)
- Pathfind towards player (bounce)
- Attack if colliders within range

### Aquarium Visitor FSM (If time permits addition of this element)
- Idle
- Pathfinding around aquarium towards attractions
- Pathfind away from attacking fish and floods
- Calculate frustration meter based on amount of leaks and attacking fish
- Pathfind to exit when frustration meter reaches the top


## 🎬 Scripted Events
New leak spawn event every 60/n seconds, where n is the number of currently existing leaks in the tank.

Attack event where an escaping fish is of the “attacking” type (Pirhanas, Sharks, Pufferfish) and will attack the aquarium worker, raising difficulty until the worker has successfully made it out of range of the shark.


## 🌍 Environment
- The main scene is an Aquarium. In the center is a giant leaking glass water tank, surrounded by sub scenes such as control rooms and tool rooms.
- The dynamic environment provides challenges. For example, water leakage causes the ground to become wet and slippery, and the water level rises over time. Some areas require diving exploration (depending on whether we have time, this may not be added).
- There are interactive elements, for example, water pipe ruptures need to be repaired with a wrench, and cracks needs to be filled with glass glue (tools need to be found in the scene).
- The main tool is the net to catch fish, but there are also maintenance tools (waterproof tape, glass repair agent, pipe clamps), to be found and equipped.
- If we have time, diving assistance devices may be added for underwater exploration (underwater thrusters (fast movement), oxygen cylinders (diving))

## 🧪 Physics Scope
- Rigidbody on fish, aquarium worker, net.
- CharacterController class on aquarium worker.
- Triggers on “puddle” objects.
- Colliders on worker, net, fish, and tank.
- Configurable joint for aquarium worker’s arms and net.
- Velocity for fish as a physics component of the fish rigidbody.
- Force-based throws, calculated as vectors based on player input.


## 🧠 FSM Scope (Game State)
- State machines implemented for various fish and water tank leaks (e.g. Normal state is fish swimming in the water tank, alarm status is first leak detected, 
escape state is fish attempting to jump out/escape and dangerous state is a new leak has occurred but has not yet been resolved).
- Event driven transformation using Unity events and C # events.
- Leakage detector (physical/virtual sensor).
- Time counter (leakage duration).
- Player interaction system (repair operation).

## 🧩 Systems and Mechanics
- Random leaks continuously appear in fish tanks around the aquarium
- Water slowly filling the floor, fish escaping
- Meter rising if too much flooding
- Level lost if meter reaches the top
- Levels increase in difficulty with more leaks, more fish, new kinds of fish
- Some fish become aggressive once they escape (Piranhas, Sharks, Pufferfish, etc)
- Protect yourself and aquarium visitors from their attacks
- Angled top down camera follows player
- Sound and Visual FX for pouring water, flopping fish, successful catch, fish attacks
- Map in top corner to display aquarium layout, different rooms, leak locations


## 🎮 Controls
- W A S D Move
- Space Jump
- Hold E next to leaks, start repairs. Hold E next to fish on the ground, pick up in net.
- Number buttons to select tool from inventory
- Hold and Release Q to throw fish back into tank
- Mouse Button 1 to swat net, defend against attacking fish
- Move mouse to aim net and catch fish
- Esc Pause
- Controller support as a stretch goal


## 🛠️ Asset Plan
Necessary Assets:
- Aquarium worker player model (x2)
- Aquarium visitor model (x4-10) (Same base model, small changes to clothes, face, hair)
- Aquarium ground tiles (stone, wood, tile)
- Aquarium walls, support beams
- Aquarium furniture (Main desk, chairs, benches)
- Glass tanks, water
- Leaking animation / model
- Fish tank toys and environment (algae, rocks, toy chest, etc)
- Fish models (x4-8)
- Net model
- Wrench model
- Glue model

We will use a combination of Unity's Asset Store and Blender for creation of these models. We are aiming for a stylized cartoon look, assets will be low poly, not very realistic.

## 📂 Project Setup aligned to course topics
- Unity 6.2 (Editor version 6000.2.5f1)
- C # scripts for PlayerController, FishController, FishEscapeDetection, CrackGenerationManager, WaterLeakageReminder, and various ToolManagers.
- NavMesh is used for AI routing.
- Physics implemented for gameplay: Catching and throwing fish, and potentially tool mechanics.
- Possible challenges in the optimization process include fish cluster rendering and water flow effect. It may be necessary to reduce performance consumption by using GPU installation and other technologies, and use HDRP pipes to achieve dynamic refraction and foam particles (use AI to generate).

## 🤝 Team Roles
All team members will participate in all elements of the game, with the following primary tasks:
- Liam: Level Design and Asset Management
- Grace: Physics and Gameplay
- Decheng: Game State and Puzzle Solving

