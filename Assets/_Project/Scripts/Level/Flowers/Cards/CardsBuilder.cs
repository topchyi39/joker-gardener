using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Level.Flowers.Cards
{
    [Serializable]
    public struct FlowerColorPair
    {
        [field: SerializeField] public Flower Flower { get; private set; }
        [field: SerializeField] public Color Color { get; private set; }
    }
    
    [Serializable]
    public class CardsBuilder
    {
        [SerializeField] private Card prefab;
        [SerializeField] private FlowerColorPair[] colors;
        
        public Card Spawn(Flower flower, Camera camera, Transform parent)
        {
            var position = PositionHelper.GetRandomWorldPosition(camera, 0.1f, 0.85f);
            position.z = 0.0111f;
            var card = Object.Instantiate(prefab, position, prefab.transform.rotation, parent);

            card.Init(flower, colors.First(item => item.Flower == flower).Color);
            return card;
        }
    }
}