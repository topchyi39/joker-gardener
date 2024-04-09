using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Level.Flowers.Cards
{
    public class CardsManager : MonoBehaviour
    {
        public IReadOnlyList<ICard> AvailableCards => _cards.Where(card => card.gameObject.activeSelf).ToArray();
        
        [SerializeField] private CardsBuilder builder;

        private Camera _mainCamera;
        private Card[] _cards;
        
        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public void Prepare(Flower[] flowers, int amount)
        {
            _cards = new Card[amount];
            
            for (var i = 0; i < amount; i++)
            {
                _cards[i] = builder.Spawn(flowers[i], _mainCamera, transform);
                _cards[i].Hide();
            }
        }

        public void ShowCards()
        {
            foreach (var card in _cards)
            {
                card.Show();
            }
        }

        public void Clear()
        {
            foreach (var card in _cards)
            {
                Destroy(card.gameObject);
            }
        }
    }
}