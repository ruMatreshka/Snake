using Snake.controller;
using Snake.view;

namespace Snake.model {
    internal abstract class BaseGameLogic : IArrowListener
    {
        public abstract void onArrowUp();
        public abstract void onArrowDown();
        public abstract void onArrowLeft();
        public abstract void onArrowRight();
       
        public abstract void update(float deltaTime, ConsoleRenderer renderer);      

        public void InitializeInput(ConsoleInput input)
        {
            input.subscribe(this);
        }      
    }
}