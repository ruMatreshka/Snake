
using Snake.controller;
using Snake.model;

internal class Program 
{
    static void Main()
    {

        var gameLogic = new SnakeGameLogic();               

        var input = new ConsoleInput();
        gameLogic.InitializeInput(input);
        gameLogic.GotoGameplay();

        var lastFrameTime = DateTime.Now;
        while (true)
        {
            input.update();
            var frameStartTime = DateTime.Now;
            float deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;
            gameLogic.update(deltaTime);
            lastFrameTime = frameStartTime;
        }
    }
}