# Assignment Three ReadMe

## Finite State Machine

### Patrolling (Unchanged from Assignment 2)

This is fish’s idle state, as it is swimming between two points.  
The fish begins the game in this state.  
Leaks will appear periodically after a set amount of seconds has passed.  
The fish remains in this patrolling state until its patrol path moves it into range of a leak that has appeared.  
When this happens, the fish transitions to the SeekLeak state.  

### SeekLeak (Unchanged from Assignment 2)

In this state, the fish swims towards the leak.  
A yellow exclamation mark appears above the fish’s head, indicating to the player that the fish will escape if the leak is not covered soon.  
The fish’s acceleration increases in this state, as it swims quickly towards the leak and is swept up in the leak’s current.  
The fish remains in this state until it reaches the leak.  
When the fish reaches the leak, it enters the Escaping state.  

### Escaping (New, did not exist in Assignment 2)

In this state, the fish waits an amount of time dependent on its size (smaller fish escape first, larger fish last). We plan to have some sort of animation playing in this time, indicating the fish is being squeezed out of the hole.    
This is the player’s last chance to cover the leak.  
After the three seconds has passed, if the leak has not been covered, the fish will have escaped.  
When this happens, the fish enters the Escaped state.  
If the player manages to cover the leak while the fish is escaping, but before it has ultimately escaped (meaning the player gets to the leak before the 3 seconds has passed), then the leak will no longer be detected by the fish, and it will transition back to the Patrolling state, rather than entering the Escaped state.  


### Escaped (Updated Since Assignment 2)

In this state, the fish shoots out of the tank. We have implemented this with physics.  
If the fish is thrown back into the tank by the player, it will return to the Patrolling state.  

### FSM Implementation
The fish's FSM is implemented using a combination of custom scripts and Unity's behavior graph feature. This allows us to visually outline each state's logic and behavior, as well as neatly define state transitions. This graph can be viewed in Unity under `Assets/Scripts/FishBehavior`.

### State Diagram

![alt text](https://github.com/LIamB12/CISC-486-3D-Game-Project/blob/assignment_1/Screenshot%202025-10-09%20172243.png)
WE NEED TO UPDATE THIS TO BE THE NEW STATE DIAGRAM

## Gameplay Video

WE NEED TO ADD VIDEO HERE

## Next Steps for our Project

### Assets
We added a lot of assets to our game, however we could still add some more. For example, animations on our fish and maybe more detailed fish assets. Another example we want to implement is a different net look when the aquarium worker's net is holding fish, rather than just parenting a fish to the net object. Updates like this will help our game look more realistic.

### Scorekeeping/Game Conditions
Currently, our game condition is a loop that only ends once the player loses because all the fish have escaped the tank. However, we want to implement more complex game conditions, for example our water level changing based on leaks.

### Further Game Details
We want to add different fish types (as in our final game there will be more than one fish), and potentially different rooms/tanks, and more NPCs such as aquarium visitors. Furthermore, it will potentially eventually be necessary to add a multiplayer version, based on Assignment 4.
