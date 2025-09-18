# 🐟 Flying Fish

## 📌 Overview

## 🕹️ Core Gameplay

## 🎯 Game Type

## 👥 Player Setup

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
- Pathfind towards player
- Attack if colliders within range

### Aquarium Visitor FSM
- Idle
- Pathfinding around aquarium towards attractions
- Pathfind away from attacking fish, floods
- Calculate frustration meter based on amount of leaks, attacking fish
- Pathfind to exit when meter reaches the top

## 🎬 Scripted Events

## 🌍 Environment
The main scene is an Aquarium Hall. The center is a giant leaking glass water tank, surrounded by sub scenes such as control rooms and tool rooms.
The dynamic environment, for example, water leakage causes the ground to become wet and slippery, and the water level rises over time. Some areas require diving exploration (depending on the situation, whether to add it or not).
There are interactive elements, for example, destructive structures like the water pipe rupture need to be repaired with a wrench, or the crack needs to be filled with glass glue (tools need to be found in the scene).
The fishing tools (retractable fishing nets), maintenance tools (waterproof tape, glass repair agent, pipe clamps).
If diving assistance devices are needed (underwater thrusters (fast movement), oxygen cylinders (diving))

## 🧪 Physics Scope

## 🧠 FSM Scope
State machines implemented for various fish and water tank leaks (e.g. Normal state is fish swimming in the water tank, alarm status is first leak detected, 
escape state is fish attempting to jump out/escape and dangerous state is a new leak has occurred but has not yet been resolved).
Event driven transformation using Unity events and C # events.
Leakage detector (physical/virtual sensor).
Time counter (leakage duration).
Player interaction system (repair operation).

## 🧩 Systems and Mechanics
- Random leaks continously appear in fish tanks around the aquarium
- Water slowly filling the floor, fish escaping
- Meter rising if too much flooding, or too many fish escape
- Level lost if meter reaches the top
- Levels increase in difficulty with more leaks, more fish, new kinds of fish
- Some fish become aggressive when escaped (Piranhas, Sharks, Pufferfish, etc)
- Protect yourself, aquarium visitors from their attacks
- Angled top down camera follows player
- Sound and Visual FX for pouring water, flopping fish, successful catch, fish attacks
- Map in top corner to see where issues pop up in the aquarium


## 🎮 Controls
- W A S D Move
- Space Jump
- Hold E next to leaks, start repairs. Hold E next to fish on the ground, pick up in net.
- Hold Q to throw fish back into tank
- Mouse Button 1 to swat net, defend against attacking fish
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

We will use a combination of Unity's Asset Store, and Blender for creation of these models. We are aiming for a stylized cartoon look, assets will be low poly, not very realistic.

## 📂 Project Setup aligned to course topics
Unity (what version? Eric is using 6000.0.36f LTS)
C # scripts for PlayerController, FishController, FishEscapeDetection, CrackGenerationManager, WaterLeakageReminder, and various ToolManagers.
NavMesh is used for AI routing.
Possible challenges in the optimization process include fish cluster rendering and water flow effect. It may be necessary to reduce performance consumption by using GPU installation and other technologies, and use HDRP pipes to achieve dynamic refraction and foam particles (use AI to generate).

