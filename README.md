# 'Puddles' console game
## Purpose
The purpose of this work is to make console game to practice my knowlegdes of users data types (class and struct), composition, inheritance, polymorphism, interfaces (but didn't use it) and single responsibility principle.
## Idea
I've got the idea for this game when I was walking at the very dark street and there was too much puddles.
######
Player should walking at the field and trying to find the way to exit with the limited vision. He cannot step on a puddle or jump through it.
## Rules
Player should press these keys to moving:
- W / UpArrow / NumPad8 - up;
- A / LeftArrow / NumPad4 - left;
- S / DownArrow / NumPad2 - down;
- D / RightArrow / NumPad6 - right;
######
In the menu player could use the same keys to changing levels.
######
You also can load your own level in menu if you made a correctly JSON file.
## Architecture
At the start I wanted to make a kind of game engine logic. I was split the logic into objects and render. Objects are just exist, have their properties, methods and know how to draw themselves. Renderer has the buffer of these objects and saying to each of these to draw themselves. The order in the buffer is important because objects draw themselves layer by layer.
######
Let's talk about data types.
#### Vector2i(int Y, int X)
I adapted (stole :)) this data type from Godot Engine. It is very comfortable to use in developing.
######
It was training of making stuct-types and overriding operators + / - / * (just for Vector2i and int) and methods Equals() and GetHashCode(). Classic.
######
It uses for positions and sizes.
#### Game
It is collection of rules of the game.
#### GameObject
You cannot make any instance of this type because all of its constuctors are protected (only for children classes). At the start I wanted to make it as an interface, but soon I change my mind and made it as a class.
######
GameObject has position, size, symbol to draw it in the console, and methods to draw it and to give their physics (just returns theirselves into each position where they are - position + size).
#### Player
Extends GameObject. Can move.
#### Puddle
Extends GameObject. Just object with some kind of alpha channel, but it doesn't uses in level loading (however, it's great idea).
#### Field
Don't extends GameObject. Practically it's just a kind of a screen where object shows.
#### Dark
It IS extends GameObject. Firstly it is just a plane copying the field. And it has a referance to the player. Player has a vision radius, and Dark overriding draw method according to player's vision radius.
#### ExitPoint
Extends GameObject. Game just checking if positions of players and exit are matching.
#### ConsoleUI
Printing the field well.
#### Renderer
As I wrote, it is getting an objects in buffer and says each of these to draw themselves.
#### LevelData
Uses to parsing JSONs to game scenes.
## How to play
You can play this game downloaded in Releases ('Puddles'). It is supports only on PCs.
## Conclusion
I made a big job :). I spent almost two weeks on this project, and it is worth it.