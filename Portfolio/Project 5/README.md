# CSCI 4830 - Project 1

## The project:
There is a maze you must traverse through. Inside the maze, coins are placed. For each set of 4 coins
you collect, you will unlock any one of the mini-games located within the maze. After completing the
mini-game, you will be one step closer to unlocking the end door. Once you have has beaten all 3
mini-games, the end door is fully unlocked. But beware! There are obstacles along the way, and you
have only so much health to spare. If you diminish all of your health, the game will be reset and
you will have to start all the way back from the beginning. Are you up to the challenge?

## Members and responsibilities:
- John Lavender
    - Design maze and arrange 3D shapes as primitives for maze
    - Write scripts for the following:
        - Game setup: controls the set up and restart logic of the game
        - Coins: logic for spawning and collecting coins
        - Obstacles: logic for spawning and moving obstacles
        - Health: logic for taking damage, regaining health, and resetting the game when health is depleted

<img src="images/JohnLavender.png" alt="drawing" width="200"/>

- Connor Moon:
    - TODO: Enter responsibilities and image here

// Connor's image here

- Spencer Chang:
    - TODO: Enter responsibilities and image here

// Spencer's image here

- Greg Steckel:
    - TODO: Enter responsibilities and image here

// Greg's image here

## Problems we encountered:
- We started out creating a new branch for each feature, and then merging that branch through a PR
  into the master branch. However, we quickly discovered that doing this less to almost-impossible-to-resolve
  merge conflicts as even minor scene edits lead to hundreds of changes in the 'scene.unity' file. Therefore,
  we had to abandon that approach and instead have only one person work at a time and push his changes
  directly to the master branch.
