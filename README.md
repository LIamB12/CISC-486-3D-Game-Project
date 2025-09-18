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

## 🧪 Physics Scope

## 🧠 FSM Scope

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
