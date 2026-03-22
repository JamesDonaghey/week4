// See https://aka.ms/new-console-template for more information
using RPG;

Console.WriteLine("Let's create a character");

GameCharacter player1 = new GameCharacter("James", 100, 50.0, 0.0, 10);
Console.WriteLine("Player deatils: " + player1);
player1.FoodAmount = 5;
Console.WriteLine("Player deatils: " + player1);
player1.Eat(3);
Console.WriteLine("Player deatils: " + player1);
