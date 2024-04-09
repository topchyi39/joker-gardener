using System;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Flowers.Pots
{
    public class PotsManager : MonoBehaviour
    {
        // public IReadOnlyList<Pot> Pots => _pots;
        public event Action AllFlowerGrown;    
        
        [SerializeField] private PotBuilder builder;
        
        private Camera _mainCamera;
        private Pot[] _pots;
        private int _flowersGrownCounts;
        
        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public void Prepare(Flower[] flowers, int amount)
        {
            _flowersGrownCounts = 0;
            
            _pots = new Pot[amount];
            for (var i = 0; i < amount; i++)
            {
                var pot = builder.Spawn(flowers[i], _mainCamera, transform);
                pot.Grown += OnFlowerGrown;
                _pots[i] = pot;
            }
        }

        private void OnFlowerGrown()
        {
            _flowersGrownCounts++;
            
            if (_flowersGrownCounts == _pots.Length)
                AllFlowerGrown?.Invoke();
        }

        public void Clear()
        {
            foreach (var pot in _pots)
            {
                Destroy(pot.gameObject);
            }
        }

        public void HideFlowers()
        {
            foreach (var pot in _pots)
            {
                pot.View.Hide();
            }
        }
    }
}