
using System.Runtime.InteropServices;
using Snake.controller;
using Snake.model;
using Snake.view;

internal class Program
{
    public static void Main()
    {
        var gameLogic = new SnakeGameLogic();
        var renderer = new ConsoleRenderer([ConsoleColor.Black, ConsoleColor.White, ConsoleColor.Red]);

        var input = new ConsoleInput();
        gameLogic.InitializeInput(input);
        gameLogic.GotoGameplay();

        var lastFrameTime = DateTime.Now;
        while (true)
        {
            input.update();
            var frameStartTime = DateTime.Now;
            float deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;
            gameLogic.update(deltaTime, renderer);
            lastFrameTime = frameStartTime;
        }
    }
}