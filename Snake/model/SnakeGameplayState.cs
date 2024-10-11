using System.Diagnostics;
using Snake.view;

namespace Snake.model
{
    internal class SnakeGamePlayState : BaseGameState
    {
        private readonly List<Cell> body = new();
        private Cell appleCell = new(1, 5);
        private SnakeDirection currentDirection = SnakeDirection.Left;

        private float timeToMove = 0f;
        private char appleSymbol = '0';
        private char snakeSymbol = '■';
        private Random _random = new();
        public bool gameOver { get; private set; }
        public bool hasWon { get; private set; }
        public int level { get; set; }


        public void setDirection(SnakeDirection direction)
        {
            currentDirection = direction;
        }

        public override void reset()
        {
            body.Clear();
            currentDirection = SnakeDirection.Right;
            body.Add(new(0, 0));
            appleCell.x = 1;
            appleCell.y = 5;
            timeToMove = 0f;
            gameOver = false;
            hasWon = false;
        }

        public override void update(float deltaTime, ConsoleRenderer renderer)
        {
            renderer.Clear();
            timeToMove -= deltaTime;
            if (timeToMove > 0f || gameOver)
                return;

            timeToMove = 1f / (4f + level);
            var head = body[0];
            var nextCell = shiftTo(head, currentDirection);
            if (nextCell.Equals(appleCell))
            {
                body.Insert(0, appleCell);
                hasWon = body.Count >= level + 3;
                GenerateApple(renderer);
                return;
            }

            body.RemoveAt(body.Count - 1);
            body.Insert(0, nextCell);
            Debug.WriteLine(nextCell.x + ":" + nextCell.y);
            if (nextCell.x < 0 || nextCell.y < 0 || nextCell.x >= renderer.width || nextCell.y >= renderer.height)
            {
                gameOver = true;
                return;
            }
            else
            {
                Draw(renderer);
                renderer.Render();
            }

        }

        public override void Draw(ConsoleRenderer renderer)
        {
            if (IsDone()) return;
            renderer.DrawString($"Level: {level}", 3, 1, ConsoleColor.White);
            renderer.DrawString($"Score: {body.Count - 1}", 3, 2, ConsoleColor.White);
            foreach (Cell cell in body)
            {
                renderer.SetPixel(cell.x, cell.y, snakeSymbol, 1);
            }
            renderer.SetPixel(appleCell.x, appleCell.y, appleSymbol, 1);
        }

        private Cell shiftTo(Cell from, SnakeDirection toDirection)
        {
            switch (toDirection)
            {
                case SnakeDirection.Up:
                    return new Cell(from.x, from.y - 1);
                case SnakeDirection.Down:
                    return new Cell(from.x, from.y + 1);
                case SnakeDirection.Left:
                    return new Cell(from.x - 1, from.y);
                case SnakeDirection.Right:
                    return new Cell(from.x + 1, from.y);
            }

            return from;
        }

        private void GenerateApple(ConsoleRenderer renderer)
        {
            Cell cell;
            cell.x = _random.Next(renderer.width);
            cell.y = _random.Next(renderer.height);
            if (body[0].Equals(cell))
            {
                if (cell.y > renderer.height / 2)
                    cell.y--;
                else
                    cell.y++;
            }
            appleCell = cell;
        }

        public override bool IsDone()
        {
            return gameOver || hasWon;
        }
    }
}