using Services.Input;
using UnityEngine.Device;

namespace Infrastracture
{
    public class Game
    {
        public static InputService InputService;

        public Game()
        {
            InitializeInputService();
        }

        private static void InitializeInputService()
        {
            if (Application.isEditor)
                InputService = new DesktopInputService();
            else
            {
                InputService = new MobileInputService();
            }
        }
    }
}