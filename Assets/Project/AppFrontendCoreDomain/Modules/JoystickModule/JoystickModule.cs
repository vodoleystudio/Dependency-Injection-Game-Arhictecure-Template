using UnityEngine;

namespace Project.AppFrontendCoreDomain.Modules
{
    public class JoystickModule : VariableJoystick, IMovementControllerModule
    {
        public Vector2 MovementDirection => Direction;
    }
}