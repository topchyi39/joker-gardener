using System;
using UnityEngine;

namespace Menu.Level.UI
{
    [Serializable]
    public struct GridPlacerSettings
    {
        public float spacing;
        public Vector2 cellSize;
        public RectTransform parent;

        public int perPage => Mathf.CeilToInt(parent.rect.width / (cellSize.x + spacing * 2)) *
                              Mathf.CeilToInt(parent.rect.height / (cellSize.y + spacing * 2));
        
        public int columns => Mathf.CeilToInt(parent.rect.width / (cellSize.x + spacing * 2));

        public float width => cellSize.x + spacing * 2;
        public float height => cellSize.y + spacing * 2;
        public float offsetX => 0;//parent.rect.width / 2;

    }   
    
    public class GridPlacer
    {
        private int _lastIndex;
        private readonly GridPlacerSettings _settings;

        public GridPlacer(GridPlacerSettings settings)
        {
            _settings = settings;
        }

        public void PlaceObject(RectTransform transform)
        {
            var row = GetRow(_lastIndex);
            var col = GetColumn(_lastIndex);
            
            var buttonPosition = new Vector2((col)  * _settings.width + _settings.width * 0.5f, -row * _settings.height);
            transform.anchoredPosition = buttonPosition;
            _lastIndex++;
        }

        private int GetRow(int index)
        {
            return (index % _settings.perPage) / _settings.columns;
        }

        private int GetColumn(int index)
        {
            return (index % _settings.perPage) % _settings.columns;
        }
    }
}