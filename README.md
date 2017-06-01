# About
Six months after enrolling in the VR Nanodegree at Udacity, I have come to my final project. This one was very broad in the 
sense that we (the students enrolled in this nanodegree) were given full creative control on what we create. The only rules 
were that the project had to earn a specific number of points in 3 different categories, and had to evoke some kind of 
emotion.

<p align="center">
<b><em>My project is called Scream, and as the name suggests, it evokes fear.</em></b>
</p>

# Unique Considerations
Sream was built for the HTC Vive, so a major design consideration was setting clear boundaries within the game since players 
have control over movement. It would not do to have players traverse to a place outside the gameplay area and break immersion. 
Another design consideration for my specific game was lighting. Since fear was the emotion I went for, it made sense to make 
the scene dark, but not too dark where players cannot get their bearings.

# Scream
The success of this game was because of the continuous iterative process implemented to systematically improve gameplay. Throughout the development of Scream, I tested, found something that needed fixing, fixed it, tested again, found something that needed fixing… and so on.

# Design Process
>Statement of Purpose: Scream is a scary, high immersion VR game for new and seasoned VR enthusiasts alike.

### Persona
<p align="center">
<img src="https://cloud.githubusercontent.com/assets/18746993/22293586/304b1a20-e2de-11e6-9577-4496042806f6.png">
<h4>Eve</h4>
</p>
>For those who don’t already know Eve, she has been my persona for [all my VR projects](https://medium.com/me/stories/public). 
>She is a 21-year-old university student who knows little about VR. Eve is a free spirit who is always ready to try new 
>things. Her favorite quote is, “Life’s too short”, so she lives in the moment.

# Sketches
Here are some sketches I made while I was thinking about the structure of the game. In the first one, I was thinking about making an alternate storyline, where one would evoke fear and the other one, exhiliration (hence the title Scream). I ended up only going with the one storyline — at least for this build. The second sketch shows the floor plan for the house. I used it as a template to build the house on blender.

<p>
<img src="https://cloud.githubusercontent.com/assets/18746993/26679446/0a605e28-46a3-11e7-9579-036feea7cd88.jpg" alt="Alternate Storyline">
Alternate Storyline Idea
<img src="https://cloud.githubusercontent.com/assets/18746993/26679543/8f7eb744-46a3-11e7-993b-24f3c84b899a.jpg" alt="Floor plan">
Floor plan
</p>

# User Testing

### Testing motion throughout the scene

At the point of the first user test, I had built the house, imported some furniture and the SteamVR plugin. I was using the SteamVR_Teleporter and SteamVR_LaserPointer scripts for teleportation. I had also added light to the scene. While testing the main scene, the player felt like the house was supposed to be “sketchy”, but it was not quite. It was also suggested that more broken furniture would the atmosphere more unnerving. Finally, the player was able to break immersion by teleporting so close to the wall that the outside of the house (and the abyss that is Unity’s scene) was seen.
I decreased the overall lighting in the house to reduce the need for more funiture and to create a dark mood. To prevent the player from teleporting too close to the wall, I added colliders to the ground of each room, making sure that they were not too close to any walls.

### Testing final game play

By the final test, I had included some diegetic features, for example, the touchpad on the left controller blinks to show players how to teleport. I had also imported some sounds and added some animation and a start scene. At this point, the only lights in the house were from the top of the headset and the ones that illuminte the keys (the collectables).
While testing, the player noted that the walls and roof were completely invisible even at fairly close distances, so it was hard to know where he was going. Another note was that the text that keeps track of the keys collected was off to the side and could easily do unnoticed. The final note was that the player was able to move to far away from his current position, and with the minimal light, it got disorienting really quickly.
To fix these issues, I changed the alpha source of the walls and roof from albedo alpha (which absorbs light) to metallic alpha (which reflects light), reducing the metallic and smoothness components to prevent the house from feeling like an abandoned factory. I also moved the text canvas to the center of the headset, when the player collects a key, the text appears — showing how many keys are left — and stays for a few seconds. Finally, I had to change the way I implemented teleportation because I could not reduce the laser pointer distance with the scripts I was using, so I used VRTK’s VRTK_Pointer and VRTK_StraightPointerRenderer scripts instead. This route was better for me because it also indicates to the player how far away teleportation is possible.

# Breakdown of final piece
Below are some screenshots of the game during the development process. Scream starts in a dark place with the only light in the scene illuminating a glowing ball. When the player touches the ball, he/she is taken into the main game scene where they have to collect all the keys in the house to escape. Also, there are monsters.

<p>
<img src="https://cloud.githubusercontent.com/assets/18746993/26679565/ad44de7a-46a3-11e7-8c02-128c4779a110.png" alt="Start Screen">
Start Screen
<img src="https://cloud.githubusercontent.com/assets/18746993/26679554/a3ef7d12-46a3-11e7-94f9-977febf2d1a4.png" alt="Fear - The House">
Fear - The House
<img src="https://cloud.githubusercontent.com/assets/18746993/26679572/b350bf50-46a3-11e7-873d-920c2c8dbe6e.png" alt="Monster">
I call them Almost Alives
</p>

# Conclusion
Scream was made to be a simple but scary immersive VR experience. The features that really brought this game to life were audio, lighting and animation.

# Next Steps
Some next steps to take Scream to another level could be to change the controllers to hands and to add an alternate storyline. To make the game scarier, the monsters could be further animated to run towards the player.

# External Links
* Gameplay - [Scream Game-play](https://vimeo.com/219580150)
