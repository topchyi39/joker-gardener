using System;
using Level.Flowers.Pots;
using UnityEngine;

namespace Level.Flowers.Cards
{
    public interface IDraggable
    {
        void StartDrag();
        void Move(Vector2 position);
        void EndDrag();
    }
    
    public class CardDragger : MonoBehaviour
    {
        private Camera _mainCamera;

        private bool _isDragged;
        private Card _currentDraggable;
        
        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var collider = ThrowRay();
                if (collider == null || !collider.TryGetComponent(out Card draggable)) return;

                _currentDraggable = draggable;
                _currentDraggable.StartDrag();
            }

            if (_currentDraggable && Input.GetMouseButton(0))
            {
                var mousePosition = Input.mousePosition;
                var origin = _mainCamera.ScreenToWorldPoint(mousePosition);
                
                _currentDraggable.Move(origin);
            }

            if (_currentDraggable && Input.GetMouseButtonUp(0))
            {
                var collider = ThrowRay();

                if (collider != null && collider.TryGetComponent(out Pot pot))
                {
                    if (pot.TrySetCard(_currentDraggable)) _currentDraggable.Hide();
                }
                
                _currentDraggable?.EndDrag();
                _currentDraggable = null;
            }
        }

        private Collider2D ThrowRay()
        {
            var mousePosition = Input.mousePosition;
            var destination = _mainCamera.ScreenToWorldPoint(mousePosition);
            return Physics2D.OverlapPoint(destination);
        }

        public void EnableDrag()
        {
            enabled = true;
        }

        public void DisableGrab()
        {
            enabled = false;
        }
    }
}