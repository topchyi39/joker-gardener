using UnityEngine;

namespace SceneManagement
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private RectTransform fillRect;

        private float _defaultX;
        
        private void Awake()
        {
            var delta = fillRect.sizeDelta;
            _defaultX = delta.x;
            delta.x = 0;
            fillRect.sizeDelta = delta;
        }

        public void SetValue(float value)
        {
            value = Mathf.Clamp01(value);
            
            var delta = fillRect.sizeDelta;
            delta.x = _defaultX * value;

            fillRect.sizeDelta = delta;
        }
    }
}