using Snake.model;
using Snake.view;

namespace Snake.model
{
    internal class ShowTextState : BaseGameState
    {
        public string text { get; set; }

        private float _duration = 1f;
        private float _timeLeft = 0f;

        public ShowTextState(float duration) : this(string.Empty, duration) { }

        public ShowTextState(string text, float duration)
        {
            this.text = text;
            _duration = duration;

            reset();
        }

        public override void Draw(ConsoleRenderer renderer)
        {
            var textHalfLength = text.Length / 2;
            var textY = renderer.height / 2;
            var textX = renderer.width / 2 - textHalfLength;
            renderer.DrawString(text, textX, textY, ConsoleColor.White);
        }

        public override void reset()
        {
            _timeLeft = _duration;
        }

        public override void update(float deltaTime, ConsoleRenderer renderer)
        {
            _timeLeft -= deltaTime;
        }

        public override bool IsDone()
        {
            return _timeLeft <= 0f;
        }
    }

}