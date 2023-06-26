using Project.AppFrontendDomain.Data;
using UnityEngine;

namespace Project.AppFrontendDomain.Pang.Data.Entities
{
    public class BubbleInitializeData
    {
        private Vector3 _position;
        public Vector3 Position => _position;

        private Vector3 _scale;
        public Vector3 Scale => _scale;

        private HorizontalDirection _horizontalDirection;
        public HorizontalDirection HorizontalDirection => _horizontalDirection;

        private float _speed;
        public float Speed => _speed;

        public BubbleInitializeData(Vector3 position, Vector3 scale, HorizontalDirection horizontalDirection, float speed)
        {
            _position = position;
            _scale = scale;
            _horizontalDirection = horizontalDirection;
            _speed = speed;
        }
    }
}