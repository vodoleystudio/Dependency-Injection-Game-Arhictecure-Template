using UnityEngine;
using Zenject;

namespace Project.AppFrontendDomain.Pang.Data.Entities
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private int _lives = 1;

        [SerializeField]
        private Transform _bulletPosition;

        public int Lives => _lives;

        private Bullet.Pool _bulletsPool;

        [Inject]
        private void Setup(Bullet.Pool bulletsPool)
        {
            _bulletsPool = bulletsPool;
        }

        public void Death()
        {
            // fire event for visual effects the same like in player-playerview
        }

        public void Hit()
        {
            // fire event for visual effects the same like in player-playerview
        }

        public void Shoot()
        {
            // fire event for visual effects the same like in player-playerview

            _bulletsPool.Spawn(new BulletInitializeData(_bulletPosition.transform.position));
        }
    }
}