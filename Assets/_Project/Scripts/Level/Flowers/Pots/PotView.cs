using System;
using System.Linq;
using UnityEngine;

namespace Level.Flowers.Pots
{
    [Serializable]
    public struct FlowerRendererPair
    {
        [field: SerializeField] public Flower Flower { get; private set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
    }    
    
    [Serializable]
    public class PotView
    {
        public Bounds PotBounds => potRenderer.bounds;
        
        [SerializeField] private SpriteRenderer potRenderer;
        [SerializeField] private FlowerRendererPair[] flowerRenderers;

        private SpriteRenderer CurrentFlower;
        
        public void ShowFlower(Flower flower)
        {
            CurrentFlower = flowerRenderers.First(item => item.Flower == flower).SpriteRenderer;
            CurrentFlower.gameObject.SetActive(true);
        }

        public void Hide()
        {
            CurrentFlower.gameObject.SetActive(false);
        }
    }
}