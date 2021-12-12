UNITY VERSION: 2020.3.24f1
Sounds: bfxr, Unity Asset Store
Assets: Unity Asset store

########################################################################################

Neil Lal
Final Project CS E23
12/12/2021

GITHUB REPO
https://github.com/Neil-Lal/SuperMarioKart50

########################################################################################

Super Mario Kart 50

Starting Scene:
IntroMenu

The game operates like any kart racing game. You start in the IntroMenu scene where you can access the controls or start the game.  Controls can also be brought up during the game (along with helpful hints about dangers you will face!) through the menu (Tab > Show controls).  The player is given a small amount of time to safely traverse the track through each checkpoint before reaching the end.  A player can lose by either 1) running out of time, 2) falling off the map (ramps are high risk high reward!), or 3) getting hit by a dangerous bowling pin (crash object).  

########################################################################################

BROAD STROKES

I used the Karting microgame from the Unity Asset store for the base framework of my project and added many features ontop to make it a more complete, robust, and entertaining game.

GOOD Goals:
The framework came with the controls and steering in place.  I created a new track and added obstacles such as rocks with collidable bodies, bowling pins that will end your game, jump ramps, alternative safer path if you can hit the jump, and speed boosts.  The ground outside the track was made incorporeal so a player can fall through and a lose condition was added to end the game if the player falls below the ground.

BETTER Goals:
Added the "Rolling Heights" area where bowling pins spawn constantly and roll across the track before despawning on the other side.  Spawns are on random intervals and getting hit means Game over, beware!

BEST Goals:
Added Powerup speed boost items to the track.  The player can collect this to get a temporary super boost to their speed (multiplies their current speed AND raises the top speed of the player temporarily).  I was not able to add a working Artificial intelligence to the game.  I felt that this ended up being too complicated and out of scope.  I chose instead to spend my time adding a lot more additional features such as a speed indicator to the bottom right of the player HUD.  We can't have a racing game without a speed display!  Additionally I added a confetti celebration when the player finishes, billboards with text because they look cool, and a flame trail for the player that grows the faster you are going.


########################################################################################

FILE SPECIFIC CHANGES

########################################################################################


SpeedIndicator [Game Object] / SpeedHUDManager.cs- Added a speed indicator to the bottom right of the player HUD. The speed text will change based on your current speed (white, yellow, red, and finally red with orange/yellow glow highlights for when you are really zooming)
ControlScheme_PopUp.png - Changed the control display to reflect the powerup hints and new danger warnings.
Powerups / TakeablePowerUp.cs - Control behavior of speed ups.  Disable on pickup and add temporary stats to kart.  Custom sound clip courtesy of bfxr.
PowerupManager - Fixed bug where powerups stop functioning on play again
Confettitrigger - SimpleTrigger -> ConfettiCelebration - Confetti celebration when finishing
GameFlowManager.cs - Adding additional lose conditions for falling through the map.
Bowling Pins - Game end on touch - CrashObject script
CrashObject.cs - Added triggers for game end and sound play on hit and player impulse
TimeManager.cs - Added method to zero time remaining to trigger end sequence
New Track Layout
New Jumps
Rock interference obstacles with mesh colliders
BillboardBasic - Jump billboard!  Rolling heights billboard.
Powerups / PowerUpContainerFlame(s) / CustomizablePowerUp.cs / TakeablePowerUp.cs - Speed boost objects in unity and the scripts that control the look and function of the speed boost powerups.
NoCheating / NoCheatingTrigger / NoCheatingScript.cs - Anti backtrack triggers with text notifications.
KartClassic_Player -Changed base stats for player - more speed = more fun!
Added flame trail to Player Kart with length based on speed
RollingHeights area - Moving crash objects dangers
CrashObjectSpawner / CrashObject Despawner / CrashObjectSpawner.cs / CrashObject Despawner.cs

Thank you!
