using UnityEngine;

namespace Project.AppFrontendCoreDomain.Modules
{
    [RequireComponent(typeof(RectTransform))]
    [DisallowMultipleComponent]
    public class Joystick : MonoBehaviour
    {
        [SerializeField]
        private Vector2 _size = new Vector2(300, 300);

        public Vector2 Size => _size;

        [HideInInspector]
        public RectTransform RectTransform;

        public RectTransform Knob;

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
        }
    }
}