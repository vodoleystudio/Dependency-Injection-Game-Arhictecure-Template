using DG.Tweening;
using UnityEngine;

namespace Project.AppFrontendDomain.Pang.Data.Entities
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField]
        private int _hitBlinkAmount = 3;

        [SerializeField]
        private float _hitBlinkDuration = 0.1f;

        private SpriteRenderer _spriteRenderer;

        private Color _defaultColor;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _defaultColor = _spriteRenderer.material.color;
        }

        public void PlayHitEffect()
        {
            _spriteRenderer.material.DOKill(true);
            _spriteRenderer.material.color = _defaultColor;

            var sequence = DOTween.Sequence();
            sequence.OnComplete(() => _spriteRenderer.material.color = _defaultColor);

            for (int i = 0; i < _hitBlinkAmount; i++)
            {
                sequence.Append(_spriteRenderer.material.DOColor(Color.red, _hitBlinkDuration));
                sequence.Append(_spriteRenderer.material.DOColor(_defaultColor, _hitBlinkDuration));
            }

            sequence.Play();
        }
    }
}