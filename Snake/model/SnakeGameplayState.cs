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
            currentDirection = SnakeDirection.Left;
            body.Add(new(0, 0));
            timeToMove = 0f;
        }

        public override void update(float deltaTime)
        {
            timeToMove -= deltaTime;
            if (timeToMove > 0f)
                return;

            timeToMove = 1f / 4;
            var head = body[0];
            var nextCell = shiftTo(head, currentDirection);

            body.RemoveAt(body.Count - 1);
            body.Insert(0, nextCell);

            Console.WriteLine($"{body[0].x}, {body[0].y}");
        }

        private Cell shiftTo(Cell from, SnakeDirection toDirection)
        {
            switch (toDirection)
            {
                case SnakeDirection.Up:
                    return new Cell(from.x, from.y + 1);
                case SnakeDirection.Down:
                    return new Cell(from.x, from.y - 1);
                case SnakeDirection.Left:
                    return new Cell(from.x - 1, from.y);
                case SnakeDirection.Right:
                    return new Cell(from.x + 1, from.y);
            }

            return from;
        }
    }
}