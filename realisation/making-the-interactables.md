# Making the Interactables

Interactables are made from 2 or 3 distinct parts: a Trigger, a Listener and optionally a condition.

![](<../.gitbook/assets/image (6).png>)

Triggers are the part the player actually interacts with. The Button is the simplest one. The switch can be turned on or off. The item pickup contains an item, or attack for now. A sensor is similar, but doesnt need to be interacted with via the interact button. Instead they work via Unity's built in physics/collision system.

Once the trigger is triggered, they send an execute command to their listeners. Multiple listeners can be added to the same trigger. For example, you pick up an item, and then display a text informing the player what they picked up.

Each listener can have conditions attached to them. If they have conditions, they will only execute if all conditions are met. For example, you can only climb a ladder from the correct side.
