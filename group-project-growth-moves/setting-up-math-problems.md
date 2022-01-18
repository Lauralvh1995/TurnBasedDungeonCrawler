# Setting up Math Problems

To work with math problems in a game, you need a way to represent these in the game. They're set up in a way that a designer could easily add more without needing to know how to program.

An equation is set up as follows, a left- and right-side integer, an operator and an answer. You can choose the operator via a dropdown menu, as it's an enum. Supported operators are addition, subtraction, multiplication and division.

Originally, the answer would return a float, to support for fractions in divisions. But after deliberation with the group, we decided that returning the fraction would not be useful for our target audience. Instead we return the integer value, and let the remainder be. Optional support for fractions, or remainders (via modulo) could be added.&#x20;

Another reason that came up for not returning a float, is that the value might fluctuate a tiny bit from the conversion of int to float. These tiny differences might throw a wrench into the whole game.

It will check if you're trying to divide by zero, and then returns a 0 and a message that you can't divide by zero.

source code for the equations themselves: [https://github.com/Lauralvh1995/AnnemariaKoekoek/blob/TableSelection/Assets/Scripts/GameManagement/Equation.cs](https://github.com/Lauralvh1995/AnnemariaKoekoek/blob/TableSelection/Assets/Scripts/GameManagement/Equation.cs)

These equations are then used to set up the multiplication tables. There you select a base number, and the game will generate the full table from 1 to 10.

source code for the table object: [https://github.com/Lauralvh1995/AnnemariaKoekoek/blob/TableSelection/Assets/Scripts/GameManagement/Table.cs](https://github.com/Lauralvh1995/AnnemariaKoekoek/blob/TableSelection/Assets/Scripts/GameManagement/Table.cs)
