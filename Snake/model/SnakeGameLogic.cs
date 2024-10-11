using System.Diagnostics;
using Snake.view;

namespace Snake.model
{
    internal class SnakeGameLogic : BaseGameLogic
    {
        private bool newGamePending = false;
        private int currLevel = 0;
        private ShowTextState showTextState = new(2f);
        private SnakeGamePlayState gameplayState = new SnakeGamePlayState();

        private void GotoGameOver()
        {
            currLevel = 0;
            newGamePending = true;
            showTextState.text = $"Game Over!";
            ChangeState(showTextState);
        }
        private void GotoNextLevel()
        {
            currLevel++;
            newGamePending = false;
            showTextState.text = $"Level {currLevel}";
            ChangeState(showTextState);
        }
        public void GotoGameplay()
        {
            gameplayState.level = currLevel;
            // gameplayState.fieldWidth = screenWidth;
            // gameplayState.fieldHeight = screenHeight;
            ChangeState(gameplayState);
            gameplayState.reset();
        }
        public override void onArrowUp()
        {
            gameplayState.setDirection(SnakeDirection.Up);
        }

        public override void onArrowDown()
        {
            gameplayState.setDirection(SnakeDirection.Down);
        }

        public override void onArrowLeft()
        {
            gameplayState.setDirection(SnakeDirection.Left);
        }

        public override void onArrowRight()
        {
            gameplayState.setDirection(SnakeDirection.Right);
        }

        public override void update(float deltaTime, ConsoleRenderer renderer)
        {
            if (currentState != null && !currentState.IsDone())
                return;
            if (currentState == null || currentState == gameplayState && !gameplayState.gameOver)
            {
                GotoNextLevel();
            }
            else if (currentState == gameplayState && gameplayState.gameOver)
            {
                GotoGameOver();
            }
            else if (currentState != gameplayState && newGamePending)
            {
                GotoNextLevel();
            }
            else if (currentState != gameplayState && !newGamePending)
            {
                GotoGameplay();
            }
        }

        public override ConsoleColor[] CreatePalette()
        {
            return
            [
                ConsoleColor.Green,
                ConsoleColor.Red,
                ConsoleColor.White,
                ConsoleColor.Blue,
            ];
        }
    }
}