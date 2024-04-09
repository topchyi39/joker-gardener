using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace UI.Fader
{
    public abstract class Fader : MonoBehaviour
    {
        [SerializeField] private float fadeDuration;

        private Sequence _fadeSequence;
        


        public void FadeIn() { Fade(true); }

        public void FadeOut() { Fade(false); }

        public void Fade(bool fade, bool immediately = false)
        {
            if (_fadeSequence is {active: true}) _fadeSequence.Kill();

            _fadeSequence = DOTween.Sequence();
            Fade(_fadeSequence, fade, immediately ? 0 : fadeDuration);
        }

        protected abstract void Fade(Sequence sequence, bool fade, float duration);
    }
}

