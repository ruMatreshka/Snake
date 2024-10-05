namespace Snake.model
{
    internal abstract class BaseGameState
    {
        public abstract void update(float deltaTime);
        public abstract void reset();
    }
}