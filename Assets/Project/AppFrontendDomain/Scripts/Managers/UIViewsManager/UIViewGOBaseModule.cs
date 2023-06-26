using UnityEngine;
using Zenject;

namespace Project.AppFrontendDomain.Managers
{
    public abstract class UIViewGOBaseModule : MonoBehaviour
    {
        protected SignalBus _signalBus;

        [Inject]
        private void Setup(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}