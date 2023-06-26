using Project.AppFrontendCoreDomain.Modules;
using Project.AppFrontendDomain.Modules;
using Project.AppFrontendDomain.Signals;
using UnityEngine;
using Zenject;

namespace Project.AppFrontendDomain.Pang.Data.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, IEntity
    {
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Weapon _weapon;

        [SerializeField]
        private Transform _weaponPosition;

        [SerializeField]
        private int _lives = 3;

        [SerializeField]
        private int _speed = 10;

        private TagsModule _tagsModule;
        private SignalBus _signalBus;
        private IMovementControllerModule _movementControllerModule;

        public int Lives => _lives;

        [Inject]
        private void Setup(SignalBus signalBus, TagsModule tagsModule, IMovementControllerModule movementControllerModule)
        {
            _tagsModule = tagsModule;
            _signalBus = signalBus;
            _movementControllerModule = movementControllerModule;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Shoot()
        {
            _weapon.Shoot();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _movementControllerModule.MovementDirection * _speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(_tagsModule.EnemyTag))
            {
                _signalBus.Fire(new EntitiesCollisionsSignal(this, other.gameObject.GetComponent<IEntity>()));
            }
        }

        public void Death()
        {
            // fire event for visual effects the same like in player-playerview

            Destroy(gameObject);
        }

        public void Hit()
        {
            _lives--;
            _signalBus.Fire(new PlayerHitSignal(Lives));
        }
    }
}