using UnityEngine;

namespace Project.AppFrontendDomain.Data
{
    public class GameSettings : ScriptableObject
    {
        public const string Name = "GameSettings";

        [SerializeField]
        private Vector2 _targetAspectRatio = new(16, 9);

        public Vector2 TargetAspectRatio => _targetAspectRatio;
    }
}