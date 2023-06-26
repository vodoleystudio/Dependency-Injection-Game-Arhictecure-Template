using System.Linq;
using UnityEngine;
using Zenject;

namespace Project.AppFrontendDomain.Pang.Data.Entities
{
    public class Bullet : MonoBehaviour, IEntity
    {
        public class Pool : MonoMemoryPool<BulletInitializeData, Bullet>
        {
            protected override void Reinitialize(BulletInitializeData bulletInitializeData, Bullet bullet)
            {
                bullet.transform.position = bulletInitializeData.Position;
                bullet.transform.rotation = Quaternion.identity;
                bullet.transform.SetParent(null);
            }
        }

        private Pool _pool;

        [SerializeField]
        private int _lives = 2;

        [SerializeField]
        private float _speed = 10f;

        public int Lives => _lives;

        [Inject]
        private void Setup(Pool pool)
        {
            _pool = pool;
        }

        private void Update()
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Death();
        }

        public void Death()
        {
            if (!_pool.InactiveItems.Contains(this))
            {
                // fire event for visual effects the same like in player-playerview

                _pool.Despawn(this);
            }
        }

        public void Hit()
        {
            // fire event for visual effects the same like in player-playerview
        }
    }
}