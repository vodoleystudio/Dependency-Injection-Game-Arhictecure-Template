using Project.AppFrontendDomain.Data;
using Project.AppFrontendDomain.Modules;
using Project.AppFrontendDomain.Signals;
using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Project.AppFrontendDomain.Pang.Data.Entities
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Bubble : MonoBehaviour, IEnemy
    {
        public class Pool : MonoMemoryPool<BubbleInitializeData, Bubble>
        {
            protected override void Reinitialize(BubbleInitializeData bubbleInitializeData, Bubble bubble)
            {
                bubble.transform.position = bubbleInitializeData.Position;
                bubble.transform.localScale = bubbleInitializeData.Scale;
                bubble.transform.rotation = Quaternion.identity;
                bubble.transform.SetParent(null);
                bubble.SetHorizontalDirection(bubbleInitializeData.HorizontalDirection);
                bubble.Speed = bubbleInitializeData.Speed;
            }
        }

        private Pool _pool;

        private const int GroundUntouched = -1;

        [SerializeField]
        private int _lives = 2;

        [SerializeField]
        private float _speed = 10f;

        public float Speed
        {
            get
            {
                return _speed;
            }
            private set
            {
                _speed = value;
            }
        }

        [SerializeField]
        private float _maxHeight = 3f;

        private float _tiltAcceleratorX = 0.3f;
        private float _tiltAcceleratorY = 0.5f;

        private float _directionY;
        private float _directionX;

        private float _lastGroundPositionY = GroundUntouched;

        private TagsModule _tagsModule;

        private SignalBus _signalBus;

        public int Lives => _lives;

        public Transform Transform => transform;

        [Inject]
        private void Setup(Pool pool, SignalBus signalBus, TagsModule tagsModule)
        {
            _pool = pool;
            _signalBus = signalBus;
            _tagsModule = tagsModule;
        }

        private void Awake()
        {
            _directionY = _tiltAcceleratorY;
            _directionX = _tiltAcceleratorX;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(_tagsModule.BulletTag))
            {
                _signalBus.Fire(new EntitiesCollisionsSignal(this, other.gameObject.GetComponent<IEntity>()));
            }
            else if (other.gameObject.CompareTag(_tagsModule.GroundTag))
            {
                if (_directionY < 0)
                {
                    SetOppositeDirection(ref _directionY);
                    _lastGroundPositionY = transform.position.y;
                }
            }
            else if (other.gameObject.CompareTag(_tagsModule.TopBorderTag))
            {
                if (_directionY > 0)
                {
                    SetOppositeDirection(ref _directionY);
                }
            }
            else if (other.gameObject.CompareTag(_tagsModule.LeftBorderTag) || other.gameObject.CompareTag(_tagsModule.RightBorderTag))
            {
                SetOppositeDirection(ref _directionX);
                _lastGroundPositionY = transform.position.y;
            }
        }

        private void Update()
        {
            if (_lastGroundPositionY != GroundUntouched && _directionY > 0 && Mathf.Abs(transform.position.y - _lastGroundPositionY) >= _maxHeight)
            {
                SetOppositeDirection(ref _directionY);
            }

            transform.position += new Vector3(_directionX, _directionY, 0f) * _speed * Time.deltaTime;
        }

        private void SetHorizontalDirection(HorizontalDirection direction)
        {
            switch (direction)
            {
                case HorizontalDirection.None:
                    break;

                case HorizontalDirection.Left:
                    _directionX = -_tiltAcceleratorX;
                    break;

                case HorizontalDirection.Right:
                    _directionX = _tiltAcceleratorX;
                    break;

                default:
                    throw new Exception($"{direction} not supported");
            }
        }

        public void Death()
        {
            // fire event for visual effects the same like in player-playerview

            if (!_pool.InactiveItems.Contains(this))
            {
                _pool.Despawn(this);
            }
        }

        public void Hit()
        {
            // fire event for visual effects the same like in player-playerview
        }

        private void SetOppositeDirection(ref float direction)
        {
            direction *= -1;
        }
    }
}