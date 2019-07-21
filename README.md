# A-StarSearchAlgorithmTask
The implementation of a popular one player game, which is available on many
smart phones. The player is given an n x n board of tiles where each tile is given one
of m colors. Each tile is connected to up to four adjacent tiles in the North, South, East,
and West directions. A tile is connected to the origin (the tile in the upper left corner) if
it has the same color as the origin and there is a path to the origin consisting only of tiles
of this color. A player does a move by choosing one of the m colors. After the choice is
made, all tiles that are connected to the origin are changed to the chosen color. The game
proceeds until all tiles of the board have the same color. The goal of the game is to
change all the tiles to the same color, preferably with the fewest number of moves
possible.

It has been proven that finding the optimal moves is a very hard computational problem.
It has also been shown that finding the minimum number of flooding operations is NPhard for m > 3. This even holds true when the player can perform flooding operations
from any position on the board. However, this variant can be solved in polynomial time
for the special case of m = 2. For an unbounded number of colors, even this variant
remains NP-hard for boards of a dimension of at least n = 3 and is solvable in polynomial
time for boards of dimension n = 2.

For the solution, a very simple greedy strategy is emplemented to solve it:
- for each move, choose the color that will result in the largest number of tiles connected to the origin;
- if there is a tie, break ties by choosing the color that has the lowest rank among the colors.

The following figure depicts a possible sequence of moves together with the chosen color on a 6 x 6 board initially filled up by 3 distinct colors.

![alt text](https://github.com/talgat-sabyrov/A-StarSearchAlgorithmTask/blob/master/Tiles.png)

An automated player that determines the color choice for each move is implemented. The goal is to determine the amount of moves and the sequence of the colors chosen by the player over the course of a game.

For the solution A* algorithm was used.
