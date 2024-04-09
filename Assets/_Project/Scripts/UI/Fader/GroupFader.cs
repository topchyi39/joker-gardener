using System;
using DG.Tweening;
using UnityEngine;

namespace UI.Fader
{
    [RequireComponent(typeof(GroupFader))]
    public class GroupFader : Fader
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private bool handleBlockRaycasts = true;
        [SerializeField] private bool handleInteractable;

        private void OnValidate()
        {
            canvasGroup ??= GetComponent<CanvasGroup>();
        }

        protected override void Fade(Sequence sequence, bool fade, float duration)
        {
            sequence.Append(canvasGroup.DOFade(fade ? 1 : 0, duration));
            if (handleInteractable) canvasGroup.interactable = fade;
            if (handleBlockRaycasts) canvasGroup.blocksRaycasts = fade;
        }
    }
}