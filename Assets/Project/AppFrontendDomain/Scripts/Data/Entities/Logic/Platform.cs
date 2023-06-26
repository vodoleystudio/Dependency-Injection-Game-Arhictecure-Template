using Project.AppFrontendDomain.Modules;
using Project.AppFrontendDomain.Signals;
using UnityEngine;
using Zenject;

namespace Project.AppFrontendDomain.Pang.Data.Entities
{
    public class Platform : MonoBehaviour, IEntity
    {
        [SerializeField]
        private int _lives = 2;

        private TagsModule _tagsModule;
        private SignalBus _signalBus;

        public int Lives => _lives;

        [Inject]
        private void Setup(TagsModule tagsModule, SignalBus signalBus)
        {
            _tagsModule = tagsModule;
            _signalBus = signalBus;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(_tagsModule.BulletTag))
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

            // fire event for visual effects the same like in player-playerview
        }
    }
}