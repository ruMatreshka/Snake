using Snake.controller;

namespace Snake.model {
    internal abstract class BaseGameLogic : IArrowListener
    {
        public abstract void onArrowUp();
        public abstract void onArrowDown();
        public abstract void onArrowLeft();
        public abstract void onArrowRight();
       
        public abstract void update(float deltaTime);      

        public void InitializeInput(ConsoleInput input)
        {
            input.subscribe(this);
        }      
    }
}