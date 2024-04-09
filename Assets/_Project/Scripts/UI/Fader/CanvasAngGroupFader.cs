using DG.Tweening;
using UnityEngine;

namespace UI.Fader
{
    public class CanvasAngGroupFader : Fader
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private bool handleBlockRaycasts = true;
        [SerializeField] private bool handleInteractable;
        
        protected override void Fade(Sequence sequence, bool fade, float duration)
        {
            if (fade) canvas.enabled = true;
            
            sequence.Append(canvasGroup.DOFade(fade ? 1 : 0, duration));
            if (!fade) sequence.AppendCallback(()=> canvas.enabled = false);
            if (handleInteractable) canvasGroup.interactable = fade;
            if (handleBlockRaycasts) canvasGroup.blocksRaycasts = fade;
        }
    }
}