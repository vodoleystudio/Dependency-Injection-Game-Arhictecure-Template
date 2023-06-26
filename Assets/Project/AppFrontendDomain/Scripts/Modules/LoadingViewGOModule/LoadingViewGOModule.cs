using DG.Tweening;
using Project.AppFrontendCoreDomain.Modules;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.AppFrontendDomain.Modules
{
    public class LoadingViewGOModule : MonoBehaviour
    {
        private const float AnimationDuration = 0.25f;

        [SerializeField]
        private Slider _progress;

        private ILoadingProgressReadonlyModule _loadingProgressReadonlyModule;

        [Inject]
        private void Setup(ILoadingProgressReadonlyModule loadingProgressReadonlyModule)
        {
            _loadingProgressReadonlyModule = loadingProgressReadonlyModule;
        }

        private IEnumerator Start()
        {
            do
            {
                DOTween.To(() => _progress.value, x => _progress.value = x, _loadingProgressReadonlyModule.Progress, AnimationDuration);
                yield return new WaitForSeconds(AnimationDuration);
            }
            while (!_loadingProgressReadonlyModule.IsDone);
            DOTween.To(() => _progress.value, x => _progress.value = x, _loadingProgressReadonlyModule.Progress, AnimationDuration).OnComplete(() => _progress.value = _loadingProgressReadonlyModule.Progress);
        }
    }
}