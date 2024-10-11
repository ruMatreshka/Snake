using Snake.controller;
using Snake.view;

namespace Snake.model
{
    internal abstract class BaseGameLogic : IArrowListener
    {
        protected BaseGameState? currentState { get; private set; }
        protected float time { get; private set; }
        protected int screenWidth { get; private set; }
        protected int screenHeight { get; private set; }
        public abstract void onArrowUp();
        public abstract void onArrowDown();
        public abstract void onArrowLeft();
        public abstract void onArrowRight();

        public abstract void update(float deltaTime, ConsoleRenderer renderer);
        public abstract ConsoleColor[] CreatePalette();
        public void InitializeInput(ConsoleInput input)
        {
            input.subscribe(this);
        }

        protected void ChangeState(BaseGameState? state)
        {
            currentState?.reset();
            currentState = state;
        }

        public void DrawNewState(float deltaTime, ConsoleRenderer renderer)
        {
            time += deltaTime;
            screenWidth = renderer.width;
            screenHeight = renderer.height;

            currentState?.update(deltaTime, renderer);
            currentState?.Draw(renderer);

            update(deltaTime, renderer);
        }
    }
}