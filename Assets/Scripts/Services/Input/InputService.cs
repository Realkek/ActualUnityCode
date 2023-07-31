using UnityEngine;

namespace Services.Input
{
    public abstract class InputService : IInputService
    {
        public abstract Vector2 Axis { get; }
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        private const string Attack = "Attack";
        
        public bool IsAttackButtonClicked()
        {
            return SimpleInput.GetButtonUp(Attack);
        }

        protected static Vector2 ReceiveSimpleInputAxis() =>
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }

    class MobileInputService : InputService
    {
        public override Vector2 Axis { get; }
    }
    
    class DesktopInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = ReceiveSimpleInputAxis();
                if (axis == Vector2.zero)
                    axis = ReceiveUnityInputAxis();
                return axis;
            }
        }

        private static Vector2 ReceiveUnityInputAxis() => new(UnityEngine.Input.GetAxis(Horizontal),
            UnityEngine.Input.GetAxis(Vertical));
    }
}