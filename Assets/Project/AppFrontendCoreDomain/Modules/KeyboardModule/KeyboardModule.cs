using UnityEngine;
using Zenject;

namespace Project.AppFrontendCoreDomain.Modules
{
    public class KeyboardModule : IMovementControllerModule, ITickable
    {
        private readonly Vector2 _leftDirection = new Vector2(-1, 0);
        private readonly Vector2 _rightDirection = new Vector2(1, 0);
        private readonly Vector2 _zeroDirection = new Vector2(0, 0);

        public Vector2 MovementDirection { get; private set; }

        public void Tick()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MovementDirection = _leftDirection;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                MovementDirection = _rightDirection;
            }
            else
            {
                MovementDirection = _zeroDirection;
            }
        }
    }
}