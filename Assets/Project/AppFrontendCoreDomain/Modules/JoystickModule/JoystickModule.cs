using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace Project.AppFrontendCoreDomain.Modules
{
    public class JoystickModule : MonoBehaviour, IMovementControllerModule
    {
        [SerializeField]
        private Joystick _joystick;

        private Finger _finger;
        public Vector2 MovementDirection { get; private set; }

        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
            Touch.onFingerDown += HandleFingerDown;
            Touch.onFingerUp += HandleLoseFinger;
            Touch.onFingerMove += HandleFingerMove;
        }

        private void OnDisable()
        {
            Touch.onFingerDown -= HandleFingerDown;
            Touch.onFingerUp -= HandleLoseFinger;
            Touch.onFingerMove -= HandleFingerMove;
            EnhancedTouchSupport.Disable();
        }

        private void HandleFingerMove(Finger movedFinger)
        {
            if (movedFinger == _finger)
            {
                Vector2 knobPosition;
                float maxMovement = _joystick.Size.x / 2f;
                Touch currentTouch = movedFinger.currentTouch;

                if (Vector2.Distance(
                        currentTouch.screenPosition,
                        _joystick.RectTransform.anchoredPosition
                    ) > maxMovement)
                {
                    knobPosition = (
                        currentTouch.screenPosition - _joystick.RectTransform.anchoredPosition
                        ).normalized
                        * maxMovement;
                }
                else
                {
                    knobPosition = currentTouch.screenPosition - _joystick.RectTransform.anchoredPosition;
                }

                _joystick.Knob.anchoredPosition = knobPosition;
                MovementDirection = knobPosition / maxMovement;
            }
        }

        private void HandleLoseFinger(Finger lostFinger)
        {
            if (lostFinger == _finger)
            {
                _finger = null;
                _joystick.Knob.anchoredPosition = Vector2.zero;
                _joystick.gameObject.SetActive(false);
                MovementDirection = Vector2.zero;
            }
        }

        private void HandleFingerDown(Finger touchedFinger)
        {
            if (_finger == null)
            {
                _finger = touchedFinger;
                MovementDirection = Vector2.zero;
                _joystick.gameObject.SetActive(true);
                _joystick.RectTransform.sizeDelta = _joystick.Size;
                _joystick.RectTransform.anchoredPosition = ClampStartPosition(touchedFinger.screenPosition);
            }
        }

        private Vector2 ClampStartPosition(Vector2 startPosition)
        {
            if (startPosition.x < _joystick.Size.x / 2)
            {
                startPosition.x = _joystick.Size.x / 2;
            }

            if (startPosition.y < _joystick.Size.y / 2)
            {
                startPosition.y = _joystick.Size.y / 2;
            }
            else if (startPosition.y > Screen.height - _joystick.Size.y / 2)
            {
                startPosition.y = Screen.height - _joystick.Size.y / 2;
            }

            return startPosition;
        }
    }
}