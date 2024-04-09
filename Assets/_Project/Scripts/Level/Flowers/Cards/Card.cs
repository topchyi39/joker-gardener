using System;
using UnityEngine;

namespace Level.Flowers.Cards
{
    public interface ICard
    {
        Flower Flower { get; }

        void Highlight();
    }
    
    public class Card : MonoBehaviour, IDraggable, ICard
    {
        public Flower Flower => _flower;

        [SerializeField] private CardView view;
        [SerializeField] private Collider2D collider2D;
        
        private Flower _flower;
        private Vector3 _pos;

        public event Action Hided;
        
        public void Init(Flower flowerType, Color color)
        {
            _flower = flowerType;
            view.SetColor(color);
        }
        
        public void Highlight()
        {
            view.Highlight();
        }

        public void StartDrag()
        {
            _pos = transform.position;
            collider2D.enabled = false;
            view.ToDragSortLayer();
        }

        public void Move(Vector2 position)
        {
            transform.position = position;
        }

        public void EndDrag()
        {
            transform.position = _pos;
            collider2D.enabled = true;
            view.ToDefaultSortLayer();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            Hided?.Invoke();
            gameObject.SetActive(false);
        }
    }
}