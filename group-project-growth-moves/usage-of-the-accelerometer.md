# Usage of the Accelerometer

I worked on reading and interpreting the values given by the accelerometer in an android phone.

We figured that the accelerometer would be the easiest way to detect movement from the user. Because we want to create games where the main mechanic is to move the phone to answer a question, detecting this movement is crucial.

At first I made a simple script that prints the current values of the accelerometer to the screen. This is a vector3 in the direction of the screen normal when at rest. After some contemplation, this observation is more than logical, as smartphones use the accelerometer to detect the phone’s orientation.

In movement, it is multiplied by the direction of the movement, from our small observations.\
This vector3 is useful, but from that we don’t directly measure the speed or acceleration of said movement. I edited the script to also print the magnitude of the vector3 we got. I don’t know exactly what acceleration is measured. The magnitude of the vector3, at rest, is almost 1. From the logs, I read that an average shake produces a vector3 with a magnitude of 5.

Comparing the magnitude at rest to the magnitude in a shake, I’ve come to the conclusion that a threshold of 2 would be good to test the movement detection against. This is because we don’t want the threshold to be too low, because that might lead to lots of false positives. You want the player to actually have to shake the phone. Too high of a threshold forces the player to shake hard enough that their phone goes flying if they don’t hold it tight.

I’ve used this detection script to power a small game where the player has to shake the phone when the correct answer to a math problem is shown. This forms the core of most of the minigames we’ve designed so far.

![At first the screen is yellow with a math problem. If you think the answer currently on screen is correct, shake.
The screen turns red if it's incorrect, and green if it's correct.](<../.gitbook/assets/image (9).png>)

source code: https://github.com/Lauralvh1995/ShootOutPOC
