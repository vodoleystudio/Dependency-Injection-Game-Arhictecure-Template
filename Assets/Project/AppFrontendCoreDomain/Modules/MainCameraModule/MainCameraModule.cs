using UnityEngine;
using Zenject;

namespace Project.AppFrontendCoreDomain.Modules
{
    public class MainCameraModule : IInitializable
    {
        private Vector2 _targetAspectRatio;
        private float _defaultCameraSize = 5f;

        [Inject]
        private void Setup(Vector2 targetAspectRatio)
        {
            _targetAspectRatio = targetAspectRatio;
        }

        public void Initialize()
        {
            Camera.main.orthographicSize = _defaultCameraSize;
            var aspectRatioOrigin = _targetAspectRatio.x / _targetAspectRatio.y;
            var aspectRatioCurrent = (float)Screen.width / Screen.height;

            if (aspectRatioCurrent < aspectRatioOrigin)
            {
                // move camera out by aspects difference in percentage
                var difference = (aspectRatioOrigin / aspectRatioCurrent) - 1f;
                var currentSize = Camera.main.orthographicSize;
                Camera.main.orthographicSize = currentSize + (difference * currentSize);
            }
        }
    }
}