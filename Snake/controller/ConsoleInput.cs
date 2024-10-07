namespace Snake.controller
{
    internal class ConsoleInput
    {
        private readonly HashSet<IArrowListener> arrowListeners = new();

        public void subscribe(IArrowListener l)
        {
            arrowListeners.Add(l);
        }

        public void update()
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        foreach (var listener in arrowListeners) listener.onArrowUp();
                        break;
                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        foreach (var listener in arrowListeners) listener.onArrowDown();
                        break;
                    case ConsoleKey.LeftArrow or ConsoleKey.A:
                        foreach (var listener in arrowListeners) listener.onArrowLeft();
                        break;
                    case ConsoleKey.RightArrow or ConsoleKey.D:
                        foreach (var listener in arrowListeners) listener.onArrowRight();
                        break;
                }
            }

        }
    }
}