using UnityEngine;

namespace Project.AppFrontendCoreDomain.Modules
{
    public interface IMovementControllerModule
    {
        Vector2 MovementDirection { get; }
    }
}