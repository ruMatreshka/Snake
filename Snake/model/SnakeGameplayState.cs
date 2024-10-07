using System.Diagnostics;
using Snake.view;

namespace Snake.model
{
    internal class SnakeGamePlayState : BaseGameState
    {
        private readonly List<Cell> body = new();
        private SnakeDirection currentDirection = SnakeDirection.Left;

        private float timeToMove = 0f;

        public void setDirection(SnakeDirection direction)
        {
            currentDirection = direction;
        }

        public override void reset()
        {
            body.Clear();
            currentDirection = SnakeDirection.Right;
            body.Add(new(0, 0));
            timeToMove = 0f;
        }

        public override void update(float deltaTime, ConsoleRenderer renderer)
        {
            renderer.Clear();
            timeToMove -= deltaTime;
            if (timeToMove > 0f)
                return;

            timeToMove = 1f / 4;
            var head = body[0];
            var nextCell = shiftTo(head, currentDirection);

            body.RemoveAt(body.Count - 1);
            body.Insert(0, nextCell);

            if (nextCell.x < 0 || nextCell.y < 0)
            {
                renderer.DrawString("END GAME!!!", (int)Math.Ceiling(renderer.width / 2d) - 5, (int)Math.Ceiling(renderer.height / 2d), ConsoleColor.Red);
                renderer.Render();
                Environment.Exit(0);
            }
            else
            {
                renderer.SetPixel(nextCell.x, nextCell.y, '■', 1);
                renderer.Render();
            }

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
    }
}