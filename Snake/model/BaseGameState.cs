using Snake.view;

namespace Snake.model
{
    internal abstract class BaseGameState
    {
        public abstract void update(float deltaTime, ConsoleRenderer renderer);
        public abstract void reset();
        public abstract void Draw(ConsoleRenderer renderer);
        public abstract bool IsDone();
    }
}