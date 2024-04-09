using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Level.Flowers.Cards
{
    [Serializable]
    public class CardView
    {
        [SerializeField] private SpriteRenderer cardRenderer;
        [SerializeField] private SpriteRenderer petalsRenderer;
        [SerializeField] private SpriteRenderer[] allRenderers;
        [SerializeField] private string defaultLayer;
        [SerializeField] private string dragLayer;
        
        [SerializeField] private Color highlightColor;
        [SerializeField] private float highlightDuration;
        
        public void SetColor(Color color)
        {
            petalsRenderer.color = color;
        }

        public void ToDefaultSortLayer()
        {
            foreach (var renderer in allRenderers)
            {
                renderer.sortingLayerName = defaultLayer;
            }
        }

        public void ToDragSortLayer()
        {
            foreach (var renderer in allRenderers)
            {
                renderer.sortingLayerName = dragLayer;
            }
        }
        
        public void Highlight()
        {
            var color = cardRenderer.color;
            
            var sequence = DOTween.Sequence();
            sequence.Append(cardRenderer.DOColor(highlightColor, highlightDuration * 0.25f));
            sequence.Append(cardRenderer.DOColor(color, highlightDuration * 0.25f));
            sequence.SetLoops(2);
        }
        
    }
}