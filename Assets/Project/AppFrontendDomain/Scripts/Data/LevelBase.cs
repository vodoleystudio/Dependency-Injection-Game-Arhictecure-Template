using Project.AppFrontendDomain.Pang.Data.Entities;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Project.AppFrontendDomain.Data
{
    public class LevelBase : MonoBehaviour, ILevel
    {
        private const float CloneSpeedOffsetStep = 0.3f;

        [SerializeField]
        private string _id;

        [SerializeField]
        private float _minEnemySize = 0.3f;

        [SerializeField]
        private int _cloneCount = 2;

        [SerializeField]
        private float _cloneDivider = 2;

        [SerializeField]
        private bool _isSpeedOffsetEnabled = false;

        private Bubble.Pool _bubblesPool;

        private List<IEnemy> _enemies = new();

        public int ActiveEnemiesCount => _enemies.Count;

        public string Id => _id;

        [Inject]
        private void Setup(Bubble.Pool bubblesPool)
        {
            _bubblesPool = bubblesPool;
        }

        private void Awake()
        {
            _enemies.AddRange(GetComponentsInChildren<IEnemy>());
        }

        public void KillEnemy(IEnemy enemy)
        {
            _enemies.Remove(enemy);
            enemy.Death();
        }

        public void HitEnemy(IEnemy enemy)
        {
            enemy.Hit();
        }

        public void Release()
        {
            Destroy(gameObject);
        }

        public void CloneEnemy(IEnemy enemy)
        {
            var newScale = enemy.Transform.localScale / _cloneDivider;
            var position = enemy.Transform.localPosition;
            var speed = enemy.Speed;
            var type = enemy.GetType();

            if (newScale.x > _minEnemySize && newScale.y > _minEnemySize && newScale.z > _minEnemySize)
            {
                for (var i = 0; i < _cloneCount; i++)
                {
                    Clone(type,
                          position,
                          newScale, i % 2 == 0 ? HorizontalDirection.Left : HorizontalDirection.Right,
                          speed + (_isSpeedOffsetEnabled ? GetRandomSpeedOffset() : 0f));
                }
            }
        }

        private void Clone(Type type, Vector3 position, Vector3 scale, HorizontalDirection direction, float speed)
        {
            IEnemy clone = null;
            if (type == typeof(Bubble))
            {
                clone = _bubblesPool.Spawn(new BubbleInitializeData(position, scale, direction, speed));
            }

            if (clone != null)
            {
                _enemies.Add(clone);
            }
        }

        private float GetRandomSpeedOffset()
        {
            return Random.Range(-CloneSpeedOffsetStep, CloneSpeedOffsetStep);
        }
    }
}