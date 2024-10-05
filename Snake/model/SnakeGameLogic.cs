namespace Snake.model 
{
    internal class SnakeGameLogic : BaseGameLogic
    {
        private SnakeGamePlayState gameplayState = new SnakeGamePlayState();        
       
        public void GotoGameplay()
        {            
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

        public override void update(float deltaTime)
        {
            gameplayState.update(deltaTime);
        }
    }
}