# Assignment Two ReadMe

## Finite State Machine

### Patrolling

This is fish’s idle state, as it is swimming between two points
The fish begins the game in this state
Leaks will appear periodically after a set amount of seconds has passed
The fish remains in this patrolling state until its patrol path moves it into range of a leak that has appeared
When this happens, the fish transitions to the SeekLeak state

### SeekLeak

In this state, the fish swims towards the leak
A yellow exclamation mark appears above the fish’s head, indicating to the player that the fish will escape if the leak is not covered soon
The fish’s acceleration increases in this state, as it swims quickly towards the leak and is swept up in the leak’s current
The fish remains in this state until it reaches the leak
When this happens, the fish transitions to the Escape state

### Escape

In this state, the fish waits 3 second (we plan to have some sort of animation playing in this time, indicating the fish is being squeezed out of the hole)
This is the player’s last chance to cover the leak
After the three seconds has passed, if the leak has not been covered, the fish will have escaped - This is indicated in our assignment by a red exclamation mark appearing above the fish’s head, however in our final game this will mean the fish shoots out of the tank and the player can catch it (this is to be implemented later with physics)
If the player manages to cover the leak while the fish is escaping, but before it has ultimately escaped (meaning the player gets to the leak before the 3 seconds has passed), then the leak will no longer be detected by the fish, and it will transition back to the Patrolling state

### FSM Implementation
The fish's FSM is implemented using a combination of custom scripts and Unity's behavior graph feature. This allows us to visually outline each state's logic and behavior, as well as neatly define state transitions. This graph can be viewed in Unity under `Assets/Scripts/FishBehavior`.

### State Diagram

![alt text](https://github.com/LIamB12/CISC-486-3D-Game-Project/blob/assignment_1/Screenshot%202025-10-09%20172243.png)

## Gameplay Video


<a href="https://youtu.be/pvzHC6C0Sdw" target="_blank">https://youtu.be/pvzHC6C0Sdw</a>

## Next Steps for our Project

### Assets
Our current fish and aquarium worker are placeholders. We will add assets in our final game, using both Blender and the assets store.

### Physics
When the fish reaches the leak, rather than a red exclamation mark appearing over its head, it should instead “jump out” of the tank, functionally becoming an object with velocity. The fish should then be able to be “caught” by the aquarium worker and “thrown back”. All of this is yet to be implemented and our plan is to consult the projectile physics  information discussed in class.
It should then be able to be “caught” by the aquarium worker and “thrown back”. All of this (physics and interaction between the fish and the aquarium worker) is yet to be implemented and our plan is to consult the projectile physics  information discussed in class.

### Scorekeeping/Game Conditions
We need an escaped fish to affect the game, and implement game conditions as in our initial ReadMe. We will have a counter for fish caught, as well as a losing condition when all the water has drained out of the tank.

### Further Game Details
We want to add different fish types (as in our final game there will be more than one fish), and potentially different rooms/tanks, and more NPCs such as aquarium visitors. Furthermore, it will eventually be necessary to add a multiplayer version.
