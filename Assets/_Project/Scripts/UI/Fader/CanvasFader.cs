using DG.Tweening;
using UnityEngine;

namespace UI.Fader
{
    public class CanvasFader : Fader
    {
        [SerializeField] private Canvas canvas;
        
        protected override void Fade(Sequence sequence, bool fade, float duration)
        {
            canvas.enabled = fade;
        }
    }
}