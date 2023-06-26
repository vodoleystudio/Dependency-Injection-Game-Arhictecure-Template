using UnityEngine;

namespace Project.AppFrontendDomain.Pang.Data.Entities
{
    public class BulletInitializeData
    {
        private Vector3 _position;
        public Vector3 Position => _position;

        public BulletInitializeData(Vector3 position)
        {
            _position = position;
        }
    }
}