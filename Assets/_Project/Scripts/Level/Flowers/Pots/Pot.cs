using System;
using Level.Flowers.Cards;
using UnityEngine;

namespace Level.Flowers.Pots
{
    public interface IPot
    {
        PotView View { get; }
        Flower Flower { get; }

        event Action Grown;
    }

    public class Pot : MonoBehaviour, IPot
    {
        public PotView View => view;
        public Flower Flower => _flower;
        
        public event Action Grown;

        [SerializeField] private PotView view;

        private Flower _flower;
        private Flower _cardFlower;
        
        public void Init(Flower flower)
        {
            _flower = flower;
            view.ShowFlower(flower);
        }

        public bool TrySetCard(ICard card)
        {
            if (_cardFlower != Flower.None) return false;
            
            _cardFlower = card.Flower;
            view.ShowFlower(_cardFlower);
            Grown?.Invoke();

            return true;
        }
        
    }
}