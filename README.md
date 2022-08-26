# GE2FinalProject
 
 Old Repo - https://github.com/ThatsGospel/GE2FinalProject

## New Plan:

I decided to create a SciFi Franchise slugfest in space. The battle consists of three “teams”. Star Wars, Star Trek and Battlestar Galactica. Each Boid would be equiped with the same Steering Behaviours; Pursue, Flee, Noise Wander and Obstacle Avoidance. Additionally I created a BoidStatesController script which using enviromental facters would help the Boids switch between the different Steering States in the appropriate situations. Given the Death Star was still present from the previous project it was the ideal centre of the battlefield. I created a StayNearOrigin script to ensure the Boids would not wander off into the depths of space. 

For the battle itself I created a Boid tracker which detected the number of Boids remaining on each team and displayed these numbers on the screen. The is also two camera modes. The main overview camera is the first one selected. Then there is also a Follow camera that cycles through the different Boids in a slightly cinematic fashion. This is done by pressing the spaceBar. You can switch back to the Overview camera by pressing Left ALT.


## Issues:

There are of course a few lingering issues. I strongly believe they could be ironed out with continued tweaking and balancing but was unable to the get all the little kinks out. First and foremost, not every battle goes the same. This level of randomisation is great in some aspects but less so in other ways. Sometimes its a bloodbath and half the ships are destroyed in the first minute. Other times it will be 5 minutes in and there has been minimal contact, let alone damage. I believe extending the Pursue distance and lowering the Wander weighting would help this but was unable to get it consistent thus far.

The Obstacle Avoidance is great for the other Boids but less so for the Death Star. They generally avoid it well, however sometimes they do go through it. Generally this affects the bigger ships like the Enterprise and Millenium Falcon more but not sure why. Last small issues are a little camera jitter on the follow camera which isn’t completely smooth yet and an issue with targeting. I believe it occurs when the Boid being  attacked by another is destroyed by a third Boid. This seems to cause issues despite making changes to the BoidStatesController to accommodate for this. In any event, when this happens the Boid will simply start shooting continuously at the Death Star until they are destroyed or their state is changed from Attack to something else in the inspector. An odd little issue but it can end up looking quite good so it isn’t overly bothersome.


## Additional Aspects:

There is a start menu with a block of text spelling out the context of the battle. There is audio in both the start menu (Also Sprach Zarathusthra) and for the battle scene (Generic Heroic Battle Music). 


The Ship Models were gotten from SketchFab.com and are linked below.

## New repo:

When doin gthe final push to my previous git repo I ran into some issues. Some files within my project had become to0 large to push to the repo using gitBash. After an hour of troubleshooting I was forced to create a new repository which I was able to push to without issue. I will reference my original repo below alongside the new one with the final project. The original will show several pushes from the last week.





## Final Video
https://youtu.be/hglsdeIsg6c



## References:

"Star Wars: TIE Fighter" (https://skfb.ly/FLnD) by Daniel is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
"Death Star (Star Wars)" (https://skfb.ly/6BNAq) by Anthony Yanez is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
"Millennium Falcon" (https://skfb.ly/osqyH) by fredbear1211 is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
Fire Ice Projectile - Explosion - https://assetstore.unity.com/packages/vfx/particles/fire-ice-projectile-explosion-217688#publisher
Volumetric Lines - https://assetstore.unity.com/packages/tools/particles-effects/volumetric-lines-29160#description
Deep Space Skybox Pack - https://assetstore.unity.com/packages/2d/textures-materials/deep-space-skybox-pack-11056#description
Music by https://www.bensound.com/free-music-for-videos
"Shuttle Typ 15" (https://skfb.ly/onnqF) by riker446 is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
"USS Enterprise D, Star Trek TNG" (https://skfb.ly/GATQ) by HaughtyGrayAlien is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
"Viper MK1" (https://skfb.ly/RtBn) by mrpetercharman is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).




